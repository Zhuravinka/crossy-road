using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public  class EventManager : MonoBehaviour
{
   public static UnityEvent onPlayerDeath = new UnityEvent();

   public static void SendPlayerDeath()
   {
      onPlayerDeath.Invoke();
   }
}
