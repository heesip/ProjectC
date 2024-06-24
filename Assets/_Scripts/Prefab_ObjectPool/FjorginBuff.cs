using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FjorginBuff : RecycleObject
{
    SpriteRenderer[] _spriteRenderers;
    Collider2D _collider;
    [SerializeField] SpriteRenderer _magicSquareSprite;
    [SerializeField] SpriteRenderer _shockWaveSprite;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        _magicSquareSprite = _spriteRenderers[0];
        _shockWaveSprite = _spriteRenderers[1];
    }

    void OnEnable()
    {
        Initialize();
    }

    void Initialize()
    {
        _magicSquareSprite.color = new Color(1, 1, 1, 0);
        _shockWaveSprite.enabled = false;
        _shockWaveSprite.color = new Color(1, 1, 1, 0.6f);
        _collider.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(AllStrings.Player))
        {
            return;
        }
        Player.Instance.GetBuff();
    }

    public void MagicSquare(float duration)
    {
        _magicSquareSprite.DOFade(1, duration);
    }

    public void ShockWave()
    {
        var sequence = DOTween.Sequence().OnComplete(Restore);
        _shockWaveSprite.enabled = true;
        sequence.Append(_shockWaveSprite.DOFade(0, 1));
        _collider.enabled = true;
    }
}
