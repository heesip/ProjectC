using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : RecycleObject
{
    Vector2 _direction;
    Vector2 _nextVec;
    [SerializeField] bool isDead;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] Rigidbody2D target;
    [SerializeField] float _speed;

    private void OnEnable()
    {
        isDead = false;
        rigid = GetComponent<Rigidbody2D>();
        target = Player.Instance.GetComponent<Rigidbody2D>();
    }


    void Run()
    {
        if (isDead)
        {
            return;
        }
        _direction = target.position - rigid.position;
        _nextVec = _direction.normalized * _speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + _nextVec);
        rigid.velocity = Vector2.zero;

    }

    private void FixedUpdate()
    {
        Run();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
        {
            return;
        }
        Restore();
    }


}
