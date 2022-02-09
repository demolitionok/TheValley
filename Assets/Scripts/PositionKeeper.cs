using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PositionKeeper : MonoBehaviour
{
    [SerializeField]
    private PositionContainer positionContainer;

    void Start()
    {
        transform.position = positionContainer.position;
    }
    
    
}
