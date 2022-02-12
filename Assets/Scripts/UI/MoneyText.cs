using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    public Text text;

    public void OnPlayerInstantiated(Player player) 
    {
        player.OnMoneyChanged += SetText;
    }

    private void SetText(float money) 
    {
        text.text = money.ToString();
    }
}
