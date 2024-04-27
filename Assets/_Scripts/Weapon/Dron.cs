using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dron : Weapon
{
    [SerializeField] Transform _dronAttackPoint1;
    [SerializeField] Transform _dronAttackPoint2;
    WaitForSeconds _coolTime = new WaitForSeconds(3);

    //Temp Code
    [SerializeField] Vector3 _dronRightPos = new Vector3(-1, 1.5f, 0);
    [SerializeField] Vector3 _dronLeftPos = new Vector3(1, 1.5f, 0);
    [SerializeField] Quaternion _dronRightRot = Quaternion.Euler(0, 0, 90);
    [SerializeField] Quaternion _dronLeftRot = Quaternion.Euler(0, 0, -90);

    private void Awake()
    {
        Initialize();
    }
    protected override void Initialize()
    {
        _rightPos = _dronRightPos;
        _leftPos = _dronLeftPos;
        _rightRot = _dronRightRot;
        _leftRot = _dronLeftRot;

    }

    private void LateUpdate()
    {
        bool isReverse = Player.Instance.IsLeft;

        transform.localRotation = isReverse ? _leftRot : _rightRot;
        transform.localPosition = isReverse ? _leftPos : _rightPos;
    }
    private void OnEnable()
    {
        _attackCoHandle = StartCoroutine(AttackCo());
    }

    Coroutine _attackCoHandle;

    IEnumerator AttackCo()
    {
        while (true)
        {
            yield return _coolTime;
            Missile missile1 = FactoryManager.Instance.GetMissile();
            Missile missile2 = FactoryManager.Instance.GetMissile();
            missile1.transform.position = _dronAttackPoint1.position;
            missile2.transform.position = _dronAttackPoint2.position;
        }
    }

    void StopAttackCo()
    {
        if (_attackCoHandle != null)
        {
            StopCoroutine(_attackCoHandle);
        }
    }

    private void OnDisable()
    {
        StopAttackCo();
    }

}
