using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FjorginBuff : RecycleObject
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(AllStrings.Player))
        {
            return;
        }
        Player.Instance.GetBuff();
    }
}
