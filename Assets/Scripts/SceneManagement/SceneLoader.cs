using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private ScriptablePlayerData initialPlayerData;

    public Vector2 loadPosition;
    public PlayerData savedData;

    public event Action<Player> OnPlayerInstantiated;

    public static SceneLoader instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        savedData = initialPlayerData.GetPlayerData();
        DontDestroyOnLoad(gameObject);
    }

    public void LoadData()
    {
        var playerGO = Instantiate(playerPrefab, loadPosition, Quaternion.identity);
        var player = playerGO.GetComponent<Player>();
        OnPlayerInstantiated?.Invoke(player);
        player.LoadData(savedData);
    }
}
