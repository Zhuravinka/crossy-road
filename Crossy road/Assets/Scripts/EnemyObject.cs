using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth health) && other.GetComponent<PlayerController>().canMove)
        {
            health.TakeDamage(1);
        }
    }
}
