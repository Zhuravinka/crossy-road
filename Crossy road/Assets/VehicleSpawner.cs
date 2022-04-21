using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{

    [SerializeField] private Vehicle vehiclePrefab;
    [SerializeField] float _minSpawnTime = 3f;
    [SerializeField] float _maxSpawnTime = 5f;

    [SerializeField] Transform spawnPosition;

    [SerializeField] bool isRight;
    private Vector3 _spawnPosition;
    void Start()
    {
        _spawnPosition = spawnPosition.position;
        StartCoroutine(SpawnCar(Random.Range(_minSpawnTime, _maxSpawnTime)));
    }
    IEnumerator SpawnCar (float spawnTime)
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(spawnTime);
            var newVehicle = Instantiate(vehiclePrefab, _spawnPosition, Quaternion.identity);
            if (isRight)
            {
                newVehicle.transform.rotation = Quaternion.Euler(0,180,0 );
            }
        }
       
    }
}
