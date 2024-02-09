using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ExpGem : RecycleObject
{
    void GetExpGem()
    {

        Restore();
    }


    void FlyExpGem()
    {
        var originalPosition = transform.position;
        var sequence = DOTween.Sequence().OnComplete(Restore);
    }

}
