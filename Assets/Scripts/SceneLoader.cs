using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private GameObject inputControllerPrefab;
    public Vector2 loadPosition;
    public PlayerData playerData;
    
    public GameObject player { get; private set; }
    public static SceneLoader instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void LoadPlayer()
    {
        player = Instantiate(playerPrefab, loadPosition, Quaternion.identity);
        player.GetComponent<PlayerDataManager>().LoadData(playerData);
        var inputController = Instantiate(inputControllerPrefab, Vector2.zero, Quaternion.identity);
        var movement = inputController.GetComponent<Movement>();
        movement.Init(player.GetComponent<Animator>(), player.GetComponent<Rigidbody2D>());
    }
}
