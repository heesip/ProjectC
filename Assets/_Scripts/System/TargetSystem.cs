using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSystem
{
    LayerMask _enemyLayer => LayerMask.GetMask(AllStrings.Enemy);
    float _circleRange = 3;
    Vector2 _boxRange = new Vector2(6, 10);
    RaycastHit2D[] _targets;

    public Transform GetNearestTarget(Vector2 playerPosition)
    {
        TargetCircleScan(playerPosition);
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
        TargetBoxScan(playerPosition);
        Transform result = null;
        if (_targets.Length > 0)
        {
            int randomIndex = Random.Range(0, _targets.Length);
            result = _targets[randomIndex].transform;
        }

        return result;
    }

    void TargetCircleScan(Vector2 playerPosition)
    {
        _targets = Physics2D.CircleCastAll(playerPosition, _circleRange, Vector2.zero, distance: 0, _enemyLayer);
    }

    void TargetBoxScan(Vector2 playerPosition)
    {
        _targets = Physics2D.BoxCastAll(playerPosition, _boxRange, angle: 0, Vector2.zero, distance: 0, _enemyLayer);
    }
}
