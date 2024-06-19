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
        _enemySpawnCoHandle = StartCoroutine(EnemySpawnCo());
        _itemBoxSpawnCoHandle = StartCoroutine(ItemBoxSpawn());
    }

    Coroutine _enemySpawnCoHandle;

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

    Coroutine _itemBoxSpawnCoHandle;
    IEnumerator ItemBoxSpawn()
    {
        while (true)
        {
            yield return _itemBoxSpawnTime;
            ItemBox itemBox = FactoryManager.Instance.GetItemBox();
            itemBox.transform.position = _spawnPoints[Random.Range(1, _spawnPoints.Length)].position;
        }
    }

    void StopCoHandle(Coroutine coHandle1, Coroutine coHandle2)
    {
        if (coHandle1 != null)
        {
            StopCoroutine(coHandle1);
        }

        if (coHandle2 != null)
        {
            StopCoroutine(coHandle2);
        }
    }

    void OnDisable()
    {
        StopCoHandle(_enemySpawnCoHandle, _itemBoxSpawnCoHandle);
    }

}
