using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    float _diffX;
    float _diffY;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
        {
            return;
        }
        AreaCheck(out _diffX, out _diffY);
        Reposition(_diffX, _diffY);

    }

    void AreaCheck(out float diffX, out float diffY)
    {
        Vector3 playerPos = Player.Instance.transform.position;
        Vector3 myPos = transform.position;
        diffX = playerPos.x - myPos.x;
        diffY = playerPos.y - myPos.y;
    }

    void Reposition(float diffX, float diffY)
    {
        float dirX = diffX < 0 ? -1 : 1;
        float dirY = diffY < 0 ? -1 : 1;
        diffX = Mathf.Abs(diffX);
        diffY = Mathf.Abs(diffY);

        if (diffX > diffY)
        {
            transform.Translate(Vector3.right * dirX * 40);
        }
        else if (diffY > diffX)
        {
            transform.Translate(Vector3.up * dirY * 40);
        }
    }

}
