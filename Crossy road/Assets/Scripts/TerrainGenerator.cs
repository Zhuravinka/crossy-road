using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] List<Row> rowSamples = new List<Row>();
    [SerializeField] List<GameObject> obstacleSamples = new List<GameObject>();
    [SerializeField] Transform parent;
    [SerializeField] PlayerController player;
    [SerializeField] GameObject lastRow;
    const int GridSize = 2;//remake
    const int SpawnDistance = 15;

    Vector3Int _emptyPosition;



    public int GetGridSize()
    {
        return GridSize;
    }

  
    void Start()
    {
        _emptyPosition = Vector3Int.FloorToInt(lastRow.transform.position/GridSize) + new Vector3Int(1,0,0);
        for (int i=0; i < 15; i++)
        {
            SpawnTerrain();
        }
        
    }
    void Update()
    {
        if (Vector3.Distance(player.transform.position/GridSize, _emptyPosition) < SpawnDistance)
        {
            SpawnTerrain();
            
        }
    }
    public void SpawnTerrain()
    {
        int whichTerrain = Random.Range(0, rowSamples.Count);
        int terrainInSuccesion = Random.Range(1, rowSamples[whichTerrain].maxInSuccession);
        for (int i = 0; i < terrainInSuccesion; i++)
        {
            GameObject newRow = Instantiate(rowSamples[whichTerrain].terrain[Random.Range(0,rowSamples[whichTerrain].terrain.Count)], _emptyPosition * GridSize, Quaternion.identity);
            newRow.transform.parent = parent;
            if(newRow.name == "Grass")
            {
                for (int j = 0; j < Random.Range(0, 5); j++)
                {
                    PlaceObstacle(obstacleSamples[Random.Range(0, obstacleSamples.Count)], _emptyPosition);
                }
            }
            _emptyPosition.x++;
        }
       


    }

    public void PlaceObstacle(GameObject obstacleSample, Vector3Int position)
    {
        Vector3Int positionInRow = new Vector3Int(position.x, 0, Random.Range(-5, 5));
        var newObstacle = Instantiate(obstacleSample, positionInRow * GridSize, Quaternion.identity);
        newObstacle.transform.parent = parent;
    }



}
