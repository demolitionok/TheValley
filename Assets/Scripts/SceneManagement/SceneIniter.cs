using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneIniter : MonoBehaviour
{
    public UnityEvent<Player> OnPlayerInstantiated;

    public void OnEnable() => SceneLoader.instance.OnPlayerInstantiated += OnPlayerInstantiated.Invoke;
    public void OnDisable() => SceneLoader.instance.OnPlayerInstantiated -= OnPlayerInstantiated.Invoke;

    void Start()
    {
        SceneLoader.instance.LoadData();
    }
}
