using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopViewController : MonoBehaviour
{
    [SerializeField]
    private List<ShopItemView> itemViews;
    private Player player;

    private void OnPlayerInstantiated(Player player) 
    {
        this.player = player;
    }

    private void OnEnable()
    {
        itemViews.ForEach(itemView => itemView.OnBuyClick += player.BuyItem);
    }
    private void OnDisable()
    {
        itemViews.ForEach(itemView => itemView.OnBuyClick -= player.BuyItem);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
