using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is created to make serializable version of IItemView
//It is needed to assign item views lists from inspector
public abstract class ItemView : MonoBehaviour, IItemView
{
    public abstract void SetItem(Item item);
}
