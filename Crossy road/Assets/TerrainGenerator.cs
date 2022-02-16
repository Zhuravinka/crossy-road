using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> terrainSamples = new List<GameObject>();
    [SerializeField] Transform parent;

    const int gridSize = 2;

    public int GetGridSize()
    {
        return gridSize;
    }
    public int GetGridPos()
    {
        return Mathf.RoundToInt(transform.position.x / gridSize);

    }
  
    void Start()
    {
        for(int position = 0; position<10; position++)
        {
            PlaceTerrain(terrainSamples[Random.Range(0, 3)], new Vector3(position, 0, 0));
        }
        
    }
    public void PlaceTerrain(GameObject terrainSample, Vector3 position)
    {
        var newRow = Instantiate(terrainSample, position * gridSize, Quaternion.identity);
        newRow.transform.parent = parent;
    }
   
    void Update()
    {
        
    }

}
