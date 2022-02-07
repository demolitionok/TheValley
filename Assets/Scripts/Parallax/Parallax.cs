using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private float parallaxFactor;

    private float length;
    private float startPos;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    { 
        transform.position += new Vector3(parallaxFactor * Time.deltaTime, 0, 0);

        if (transform.position.x >= startPos + length || transform.position.x <= startPos - length)
            transform.position = new Vector3(startPos, 0, 0);

    }
}
