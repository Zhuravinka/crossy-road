using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> terrainSamples = new List<GameObject>();
    [SerializeField] List<GameObject> obstacleSamples = new List<GameObject>();
    [SerializeField] Transform parent;
    [SerializeField] PlayerController player;
    [SerializeField] Row lastRow;
    const int gridSize = 2;//remake
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
        if(terrainSample.name == "Grass")
        {
            for (int i = 0; i < Random.Range(0, 5); i++)
            {
                PlaceObstacle(obstacleSamples[Random.Range(0, 2)], position);
            }
        }


    }

    public void PlaceObstacle(GameObject obstacleSample, Vector3Int position)
    {
        Vector3Int positionInRow = new Vector3Int(position.x, 0, Random.Range(-5, 5));
        var newObstacle = Instantiate(obstacleSample, positionInRow * gridSize, Quaternion.identity);
        newObstacle.transform.parent = parent;
    }



}
