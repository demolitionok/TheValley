using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneIniter : MonoBehaviour
{
    public UnityEvent<Player> OnPlayerInstantiated;
    public UnityEvent<Player> OnPlayerLoaded;

    public void OnEnable()
    {
        SceneLoader.instance.OnPlayerInstantiated += OnPlayerInstantiated.Invoke;
        SceneLoader.instance.OnPlayerLoaded += OnPlayerLoaded.Invoke;
    }

    void Start()
    {
        SceneLoader.instance.LoadData();

        OnPlayerInstantiated = null;
        OnPlayerLoaded = null;
    }
}
