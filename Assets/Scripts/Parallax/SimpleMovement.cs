using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private void FixedUpdate()
    {
        gameObject.transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
    }
}
