using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public Item item;
    private Player player;
    private SpriteRenderer spriteRenderer;

    public void SetPlayer(Player player) 
    {
        this.player = player;
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.sprite;
    }

    public void PlayerPickUp() 
    {
        player.PickUpItem(item);
        Destroy(gameObject);
    }
}
