using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
       // if (PlayerController.isDead)
      //  {
       //     return;
       // }

       // StartCoroutine(collider.transform.GetComponent<PlayerController>().Die());
    }
}
