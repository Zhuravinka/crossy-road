using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{

    [SerializeField] Vehicle vehiclePrefab;

    [SerializeField] float _minSpawnTime = 3f;
    [SerializeField] float _maxSpawnTime = 5f;

    void Update()
    {
        StartCoroutine(SpawnCar(Random.Range(_minSpawnTime, _maxSpawnTime)));
    }
    IEnumerator SpawnCar (float spawnTime)
    {
        var newVehicle = Instantiate(vehiclePrefab, vehiclePrefab.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(spawnTime);
    }
}
