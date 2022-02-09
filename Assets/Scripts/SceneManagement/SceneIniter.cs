using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneIniter : MonoBehaviour
{
    public UnityEvent OnPlayerLoaded;

    void Start()
    {
        SceneLoader.instance.LoadPlayer();
        OnPlayerLoaded?.Invoke();
    }
}
