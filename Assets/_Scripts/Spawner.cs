using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform[] _spawnPoints;
    WaitForSeconds _spawnTime;

    void Start()
    {
    }

    void OnEnable()
    {
        _spawnPoints = GetComponentsInChildren<Transform>();
        _SpawnCoHandle = StartCoroutine(EnemySpawn(2));
    }

    Coroutine _SpawnCoHandle;

    IEnumerator EnemySpawn(float spawnTime)
    {
        while (true)
        {
            _spawnTime = new WaitForSeconds(spawnTime);
            Enemy enemy = FactoryManager.Instance.GetEnemy();
            enemy.transform.position = _spawnPoints[Random.Range(1, _spawnPoints.Length)].position;
            yield return _spawnTime;
        }
    }

    void StopSpawnCo()
    {
        if (_SpawnCoHandle != null)
        {
            StopCoroutine(_SpawnCoHandle);
        }
    }


    private void OnDisable()
    {
        StopSpawnCo();
    }
}
