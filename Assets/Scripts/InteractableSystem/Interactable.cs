using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour, IInteractable
{
    private UnityEvent OnInteraction;

    public void Interact()
    {
        OnInteraction?.Invoke();
    }

    public Vector2 GetPosition() => transform.position;
}
