using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Row", menuName = "Row")]
public class Row : ScriptableObject
{
    public List<GameObject> terrain;
    public int maxInSuccession;
   
}
