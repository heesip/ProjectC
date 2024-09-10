using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ExpGem : RecycleObject
{
    bool _isFly;
    float _duration = 0.3f;
    [SerializeField] GameObject _light;

    void OnEnable()
    {
        _isFly = false;
        _light.SetActive(!_isFly);
    }

    void OnDisable()
    {
        if (!_isFly)
        {
            return;
        }

        Player.Instance.GetExpGem();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(AllStrings.Player) && !collision.CompareTag(AllStrings.Magnet))
        {
            return;
        }
        FlyExpGem();
    }

    void FlyExpGem()
    {
        if (_isFly)
        {
            return;
        }

        _isFly = true;
        _light.SetActive(!_isFly);
        var playerPosition = Player.Instance.transform.position;
        var sequence = DOTween.Sequence();

        Vector3 direction = (transform.position - playerPosition).normalized;
        Vector3 target = gameObject.transform.position + direction;
        sequence.Append(transform.DOMove(target, _duration));
        sequence.Append(transform.DOMove(playerPosition, _duration));
        sequence.Join(transform.DOScale(Vector3.zero, _duration)).OnComplete(Restore);
    }
}