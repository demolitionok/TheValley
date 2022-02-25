using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    private Vector2 newPlayerPosition;
    [SerializeField]
    private string newSceneName;

    public void SetLoadPosition() 
    {
        SceneLoader.instance.loadPosition = newPlayerPosition;
    }
    public void LoadNewScene() 
    {
        SceneManager.LoadScene(newSceneName);
    }
}
