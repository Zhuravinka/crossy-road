using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{

    [SerializeField] Vehicle vehiclePrefab;

    [SerializeField] float _minSpawnTime = 3f;
    [SerializeField] float _maxSpawnTime = 5f;

    private Vector3 _position;

    private void OnEnable()
    {
        _position = GetComponent<Transform>().position;
    }
    private void Start()
    {
        StartCoroutine(SpawnCar(Random.Range(_minSpawnTime, _maxSpawnTime)));
    }

   
    
    IEnumerator SpawnCar (float spawnTime)
    {
       // int i = 0;
       // while(i < 10) //todo MAKE THE BOOLEAN VARIABLE
       // {
            Vector3 spawnPosition = new Vector3(_position.x, 0, -5);
            var newVehicle = Instantiate(vehiclePrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
       //     i++;
       // }
       
    }
}
