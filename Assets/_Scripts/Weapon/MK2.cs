using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MK2 : Weapon
{
    [SerializeField] GameObject _mk2;
    [SerializeField] SpriteRenderer _mk2Sprite;
    [SerializeField] Collider2D _collider;
    //Temp Code
    [SerializeField] Vector3 _mk2RightPos = new Vector3(-2f, 0, 0);
    [SerializeField] Vector3 _mk2LeftPos = new Vector3(2f, 0, 0);
    [SerializeField] Quaternion _mk2Rot = Quaternion.Euler(0, 0, -90);

    WaitForSeconds _coolTime = new WaitForSeconds(3);
    protected override void Initialize()
    {
        _mk2Sprite = _mk2.GetComponent<SpriteRenderer>();
        _collider = _mk2.GetComponent<Collider2D>();
        _mk2.transform.rotation = _mk2Rot;

        _rightPos = _mk2RightPos;
        _leftPos = _mk2LeftPos;
        _mk2.transform.Translate(transform.up, Space.World);
        _speed = 2.2f;

    }

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        _attackCoHandle = StartCoroutine(AttackCo());
    }
    private void OnDisable()
    {
        StopAttackCo();
    }

    Coroutine _attackCoHandle;
    IEnumerator AttackCo()
    {
        float attackTime = 0;
        float maxAttackTime = 2f;
        while (true)
        {
            attackTime = 0;
            AttackPosition();
            while (attackTime < maxAttackTime)
            {
                yield return null;
                Vector3 rotVec = Vector3.back;
                transform.Rotate(rotVec * _speed);
                attackTime += Time.deltaTime;
            }
            WeaponReturn();
            yield return _coolTime;
        }
    }

    void StopAttackCo()
    {
        if (_attackCoHandle != null)
        {
            StopCoroutine(_attackCoHandle);
        }
    }

    void AttackPosition()
    {
        bool isReverse = Player.Instance.IsLeft;
        _mk2Sprite.enabled = true;
        _collider.enabled = true;
        transform.localPosition = isReverse ? _leftPos : _rightPos;
        transform.SetParent(null);
    }

    void WeaponReturn()
    {
        _collider.enabled = false;
        _mk2Sprite.enabled = false;
        transform.SetParent(Player.Instance.transform);
    }
}
