using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Item
{
    BoxCollider2D _boxCollider;
    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    protected override void ItemFunction()
    {
        _boxCollider.enabled = true;
    }
    protected override void OnStart()
    {
        _boxCollider.enabled = false;
    }
}

