using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    Vector3 _rightPosition = new Vector3(3.5f, 0);
    Vector3 _leftPosition = new Vector3(-3.5f, 0);
    Animator _animator;
    Collider2D _collider;
    float _damage;

    public void Initialize()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();

        _collider.enabled = false;
    }

    public void Positioning(Vector3 dronPosition)
    {
        transform.position = Player.Instance.IsLeft ? dronPosition + _leftPosition : dronPosition + _rightPosition;
        _spriteRenderer.flipX = Player.Instance.IsLeft;
    }

    public void Attack(float damage)
    {
        _damage = damage;
        _animator.SetTrigger(AllStrings.Attack);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(AllStrings.Enemy))
        {
            return;
        }
        var enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.OnDamage(gameObject, _damage);
        }
    }
}
