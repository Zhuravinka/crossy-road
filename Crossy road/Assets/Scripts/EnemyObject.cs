using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out PlayerHealth health) )
        {
            health.TakeDamage(1);
        }
    }

}
