using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSystem
{
    LayerMask _enemyLayer => LayerMask.GetMask(AllStrings.Enemy);
    float _scanRange = 3;
    RaycastHit2D[] _targets;

    public Transform GetNearestTarget(Vector2 playerPosition)
    {
        TargetScan(playerPosition);
        Transform result = null;
        float distance = 100;

        foreach (RaycastHit2D target in _targets)
        {
            Vector3 targetPosition = target.transform.position;
            float currentDistance = Vector2.Distance(playerPosition, targetPosition);

            if (distance > currentDistance)
            {
                distance = currentDistance;
                result = target.transform;
            }
        }
        return result;
    }

    public Transform GetRandomTarget(Vector2 playerPosition)
    {
        Transform result = null;
        TargetScan(playerPosition);
        if (_targets.Length > 0)
        {
            int randomIndex = Random.Range(0, _targets.Length);
            result = _targets[randomIndex].transform;
        }

        return result;
    }

    void TargetScan(Vector2 playerPosition)
    {
        _targets = Physics2D.CircleCastAll(playerPosition, _scanRange, Vector2.zero, 0, _enemyLayer);
    }
}
