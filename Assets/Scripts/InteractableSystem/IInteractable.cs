using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IInteractable
{
    public abstract Vector2 GetPosition();
    public abstract void Interact(); 
}
