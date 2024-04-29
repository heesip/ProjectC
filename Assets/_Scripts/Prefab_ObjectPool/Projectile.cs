using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : RecycleObject
{
    Rigidbody2D _rigid;
    //SpriteRenderer _sprite;
    [SerializeField] float speed = 5;
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
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
                _rigid.velocity = Vector2.left * speed;
                break;
            case false:
                _rigid.velocity = Vector2.right * speed;
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
        _rigid.velocity = Vector2.zero;
        Restore();
    }
}
