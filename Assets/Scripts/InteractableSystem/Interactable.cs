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
        Debug.Log("AAAAAAAAAAAA INTERAKKKKTED");
    }

    public Vector2 GetPosition() => transform.position;
}
