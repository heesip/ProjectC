using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Item
{
    BoxCollider2D _boxCollider;

    protected override void ItemFunction()
    {
        gameObject.tag = AllStrings.Player;
        _boxCollider.enabled = true;
    }
    protected override void OnStart()
    {
        gameObject.tag = AllStrings.Item;
        _boxCollider.enabled = false;
    }

    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }
}

