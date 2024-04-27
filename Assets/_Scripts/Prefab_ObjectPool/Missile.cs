using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : RecycleObject
{
    Rigidbody2D rigid;
    [SerializeField] float speed = 5;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        Shot();
    }

    void Shot()
    {
        bool isReverse = Player.Instance.IsLeft;

        switch (isReverse)
        {
            case true:
                transform.Rotate(0, 0, 180);
                rigid.velocity = Vector2.left * speed;
                break;
            case false:
                rigid.velocity = Vector2.right * speed;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
        {
            return;
        }
        Remove();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
        {
            return;
        }
        Remove();
    }
    private void Remove()
    {
        rigid.velocity = Vector2.zero;
        Restore();
    }
}
