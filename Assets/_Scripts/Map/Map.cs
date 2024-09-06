using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    readonly int _moveDistance = 200;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag(AllStrings.Area))
        {
            return;
        }
        Reposition(collision);
    }
    void Reposition(Collider2D collision)
    {
        Vector3 direction = collision.transform.position - transform.position;
        float directionX = direction.x < 0 ? -1 : 1;
        float directionY = direction.y < 0 ? -1 : 1;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            transform.Translate(Vector3.right * directionX * _moveDistance);
        }
        else if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
        {
            transform.Translate(Vector3.up * directionY * _moveDistance);
        }
        else
        {
            transform.Translate(new Vector3(directionX, directionY, 0).normalized * _moveDistance);
        }
    }

}
