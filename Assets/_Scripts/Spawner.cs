using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform[] _spawnPoints;
    WaitForSeconds _spawnTimeCo;

    //TempCode
    [SerializeField] float _spawnTime = 2.5f;

    void OnEnable()
    {
        Initialize();
    }

    void Initialize()
    {
        transform.parent = Player.Instance.transform;
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.one;
        _spawnPoints = GetComponentsInChildren<Transform>();
        _SpawnCoHandle = StartCoroutine(EnemySpawn());
    }

    Coroutine _SpawnCoHandle;

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            _spawnTimeCo = new WaitForSeconds(_spawnTime);
            Enemy enemy = FactoryManager.Instance.GetEnemy();
            enemy.transform.position = _spawnPoints[Random.Range(1, _spawnPoints.Length)].position;
            yield return _spawnTimeCo;
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
