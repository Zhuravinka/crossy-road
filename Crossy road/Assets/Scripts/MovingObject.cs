using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{

    [SerializeField] float speed = 4;

    void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    
}
