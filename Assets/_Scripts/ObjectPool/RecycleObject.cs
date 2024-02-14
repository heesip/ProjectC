using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleObject : MonoBehaviour
{
    Action<RecycleObject> _restore;

    public void InitializedByObjectPoolSystem(Action<RecycleObject> restore)
    {
        _restore = restore;
    }

    protected void Restore()
    {
        _restore(this);
    }


}
