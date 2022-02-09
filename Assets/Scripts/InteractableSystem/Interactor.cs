using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

[RequireComponent(typeof(Collider2D))]
public class Interactor : MonoBehaviour
{
    [SerializeField]
    private InputActionReference interactReference;
    private InputAction interactAction;
    private HashSet<IInteractable> currentInteractables;

    private void Awake()
    {
        interactAction = interactReference.action;
    }

    private void OnEnable() => interactAction.performed += OnInteraction;
    private void OnDisable() => interactAction.performed -= OnInteraction;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            currentInteractables.Add(interactable);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            currentInteractables.Remove(interactable);
        }
    }

    private IInteractable ClosestInteractable(IInteractable a, IInteractable b)
    {
        var aDist = Vector2.Distance(transform.position, a.GetPosition());
        var bDist = Vector2.Distance(transform.position, b.GetPosition());

        return aDist > bDist ? b : a;
    }

    private void OnInteraction(InputAction.CallbackContext ctx) 
    {
        if (ctx.ReadValueAsButton() && currentInteractables.Count > 0)
        {
            var closestInteractable = currentInteractables.Aggregate(ClosestInteractable);
            closestInteractable.Interact();
        }
        
    }
}
