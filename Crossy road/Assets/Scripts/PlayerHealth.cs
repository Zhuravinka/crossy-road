using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private int _health = 1;
    
    public void TakeDamage(int damage)
    {
        if (_health > 0)
        {
            _health -= damage;
        }
        else
        {
            _health = 0;
            Die();
        }
    }
    
    void Die()
    {
      EventManager.SendPlayerDeath();
    }
}
