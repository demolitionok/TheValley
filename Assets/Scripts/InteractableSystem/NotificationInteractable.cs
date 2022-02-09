using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationInteractable : Interactable
{
    public GameObject text;

    public override void ShowNotification() 
    {
        text.SetActive(true);
    }
    public override void HideNotification()
    {
        text.SetActive(false);
    }
}
