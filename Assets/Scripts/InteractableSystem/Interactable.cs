using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private UnityEvent OnInteraction;

    public void Interact()
    {
        OnInteraction?.Invoke();
        Debug.Log("interacted");
    }

    public Vector2 GetPosition() => transform.position;

    public virtual void ShowNotification() { }

    public virtual void HideNotification() { }
}
