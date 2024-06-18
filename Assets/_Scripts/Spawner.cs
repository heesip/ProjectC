using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField]
    WaitForSeconds[] _enemySpawnTimes = new WaitForSeconds[]
    {
        new WaitForSeconds(3.5f), new WaitForSeconds(3),new WaitForSeconds(2.5f),
        new WaitForSeconds(2), new WaitForSeconds(1.5f)
    };
    [SerializeField] WaitForSeconds _itemBoxSpawnTime = new WaitForSeconds(10);

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
        _spawnCoHandle = StartCoroutine(EnemySpawnCo());
    }

    Coroutine _spawnCoHandle;

    IEnumerator EnemySpawnCo()
    {
        while (true)
        {
            Enemy enemy = FactoryManager.Instance.GetEnemy();
            enemy.transform.position = _spawnPoints[Random.Range(1, _spawnPoints.Length)].position;
            enemy.LevelValue(GameManager.Instance.Level);
            yield return _enemySpawnTimes[GameManager.Instance.Level];
        }
    }

    IEnumerator ItemBoxSpawn()
    {
        while (true)
        {

            yield return _itemBoxSpawnTime;
        }
    }

    void StopCoHandle()
    {
        if (_spawnCoHandle != null)
        {
            StopCoroutine(_spawnCoHandle);
        }
    }

    void OnDisable()
    {
        StopCoHandle();
    }

}
