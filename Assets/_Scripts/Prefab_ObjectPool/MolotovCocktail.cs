using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

public class MolotovCocktail : Item
{
    WaitForSeconds _throwingReady = new WaitForSeconds(2f);
    Vector3 _rotate360 = new Vector3(0, 0, 360);
    float _speed = 0.5f;
    float _range = 1.7f;

    protected override void ItemFunction()
    {
        Throwing();
    }

    protected override void GetItem()
    {
        if (_isGet)
        {
            return;
        }

        _isGet = true;
        ItemFunction();
    }

    void Throwing()
    {
        Vector3 playerPosition = Player.Instance.transform.position;
        Vector3 direction = (transform.position - playerPosition).normalized;
        Vector3 target = gameObject.transform.position + direction * _range;
        var sequence = DOTween.Sequence().OnComplete(Bomb);
        sequence.Append(transform.DOMove(target, _speed));
        sequence.Join(transform.DORotate(_rotate360, _speed, RotateMode.FastBeyond360));
        AudioManager.Instance.PlaySFX(SFXType.Throwing);
    }

    void Bomb()
    {
        Flame flame = FactoryManager.Instance.GetFlame();
        flame.AttackPoint(transform.position);
        Restore();
    }
}
