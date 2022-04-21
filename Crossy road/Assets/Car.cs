using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Vehicle
{

    [SerializeField] float speed = 4;

    void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            other.GetComponent<Animator>().SetBool("isDead",true);
           // Destroy(other.gameObject);
        }
    }
}
