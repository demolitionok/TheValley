using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public Sprite icon;
    public bool equipable;
    public string itemName;
    public float price;
}
