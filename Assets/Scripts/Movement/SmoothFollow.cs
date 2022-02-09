using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float speed;

    public void SetTarget() 
    {
        target = SceneLoader.instance.player.transform;
    }

    void FixedUpdate()
    {
        var newX = Mathf.Lerp(transform.position.x, target.position.x, speed);
        var newY = Mathf.Lerp(transform.position.y, target.position.y, speed);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}
