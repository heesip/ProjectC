using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStar : MonoBehaviour
{
    [SerializeField] Sprite[] _sprites;
    SpriteRenderer _sprite;
    [SerializeField] bool _isRare;


    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        switch (_isRare)
        {
            case false:
                _sprite.sprite = _sprites[0];
                break;
            case true:
                _sprite.sprite = _sprites[1];
                break;
        }
    }
}
