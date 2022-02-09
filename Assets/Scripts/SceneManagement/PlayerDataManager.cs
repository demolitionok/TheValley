using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public PlayerData playerData;

    public void LoadData(PlayerData data) 
    {
    }

    public PlayerData GetData() 
    {
        return playerData;
    }

    private void OnDestroy()
    {
        SceneLoader.instance.playerData = playerData;
    }
}
