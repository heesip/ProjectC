using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    float _differenceX;
    float _differenceY;

    //Temp Code
    int _moveDistance = 40;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag(AllStrings.Area))
        {
            return;
        }
        AreaCheck(out _differenceX, out _differenceY);
        Reposition(_differenceX, _differenceY);

    }

    void AreaCheck(out float differenceX, out float differenceY)
    {
        Vector3 playerPosition = Player.Instance.transform.position;
        Vector3 myPosition = transform.position;
        differenceX = playerPosition.x - myPosition.x;
        differenceY = playerPosition.y - myPosition.y;
    }

    void Reposition(float differenceX, float differenceY)
    {
        float directionX = differenceX < 0 ? -1 : 1;
        float directionY = differenceY < 0 ? -1 : 1;
        differenceX = Mathf.Abs(differenceX);
        differenceY = Mathf.Abs(differenceY);

        if (differenceX > differenceY)
        {
            transform.Translate(Vector3.right * directionX * _moveDistance);
        }
        else if (differenceY > differenceX)
        {
            transform.Translate(Vector3.up * directionY * _moveDistance);
        }
    }

}
