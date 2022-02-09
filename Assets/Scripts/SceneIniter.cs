using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneIniter : MonoBehaviour
{
    void Start()
    {
        SceneLoader.instance.LoadPlayer();
    }
}
