using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Vehicle
{

    [SerializeField] float speed = 4;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }


}
