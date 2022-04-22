using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MovingObjectsSpawner : MonoBehaviour
{

    [SerializeField] private List<GameObject>  objectsPrefabs;
    [SerializeField] float _minSpawnTime = 1f;
    [SerializeField] float _maxSpawnTime = 5f;

    [SerializeField] Transform spawnPosition;

    private bool _isRight;
    private Vector3 _spawnPosition;
    private GameObject _prefab;
    void Start()
    {
       
        _prefab = objectsPrefabs[Random.Range(0, objectsPrefabs.Count)];
        _spawnPosition = spawnPosition.position;
        if (_spawnPosition.z > 0)
        {
            _isRight = true;
        }
        else _isRight = false;
        StartCoroutine(SpawnCar(Random.Range(_minSpawnTime, _maxSpawnTime)));
    }
    IEnumerator SpawnCar (float spawnTime)
    {
        for (int i = 0; i < 10; i++)
        {
           
            var newVehicle = Instantiate(_prefab, _spawnPosition, Quaternion.identity);
            if (_isRight)
            {
                newVehicle.transform.rotation = Quaternion.Euler(0,180,0 );
            }
            yield return new WaitForSeconds(spawnTime);
        }
       
    }
}
