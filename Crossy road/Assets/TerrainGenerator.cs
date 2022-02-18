using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> terrainSamples = new List<GameObject>();
    [SerializeField] Transform parent;
    [SerializeField] PlayerController player;
    [SerializeField] Row lastRow;
    const int gridSize = 2;//remove
    const int spawnDistance = 15;

    Vector3Int emptyPosition;



    public int GetGridSize()
    {
        return gridSize;
    }

  
    void Start()
    {
        emptyPosition = Vector3Int.FloorToInt(lastRow.transform.position/gridSize) + new Vector3Int(1,0,0);
        for (; emptyPosition.x < 15; emptyPosition.x++)
        {
            PlaceTerrain(terrainSamples[Random.Range(0, 3)], emptyPosition);
        }
        
    }
    void Update()
    {
        if (Vector3.Distance(player.transform.position/gridSize, emptyPosition) < spawnDistance)
        {
            PlaceTerrain(terrainSamples[Random.Range(0, 3)], emptyPosition);
            emptyPosition.x++;
        }
    }
    public void PlaceTerrain(GameObject terrainSample, Vector3Int position)
    {
        var newRow = Instantiate(terrainSample, position * gridSize, Quaternion.identity);
        newRow.transform.parent = parent;
    }
   
   

}
