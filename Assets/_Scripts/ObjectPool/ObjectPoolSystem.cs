using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolSystem
{

    RecycleObject _recycleObjectPrefab;
    RecycleObject _tempObject;
    List<RecycleObject> _objectPool = new List<RecycleObject>();
    int LAST_INDEX => _objectPool.Count - 1;
    Transform _parent;
    Quaternion _originalRotate;
    int _defaultPoolSize;

    public ObjectPoolSystem(RecycleObject recycleObjectPrefab, int defaultPoolSize, Transform parent)
    {
        if (defaultPoolSize <= 0)
        {
            defaultPoolSize = 1;
        }

        _recycleObjectPrefab = recycleObjectPrefab;
        _defaultPoolSize = defaultPoolSize;
        _parent = parent;
        _originalRotate = recycleObjectPrefab.transform.localRotation;
    }

    void CreateObject()
    {
        for (int i = 0; i < _defaultPoolSize; i++)
        {
            _tempObject = MonoBehaviour.Instantiate(_recycleObjectPrefab, _parent);
            _tempObject.InitializedByObjectPoolSystem(Restore);
            _tempObject.gameObject.SetActive(false);
            _objectPool.Add(_tempObject);
        }
    } 

    public RecycleObject Get()
    {
        if (_objectPool.Count <= 0)
        {
            CreateObject();
        }

        _tempObject = _objectPool[LAST_INDEX];
        _objectPool.RemoveAt(LAST_INDEX);
        _tempObject.gameObject.SetActive(true);
        return _tempObject;
    }

    public void Restore(RecycleObject recycleObject)
    {
        if (_objectPool.Contains(recycleObject)) return;

        recycleObject.gameObject.SetActive(false);
        recycleObject.transform.localScale = Vector3.one;
        recycleObject.transform.localRotation = _originalRotate;
        recycleObject.transform.SetParent(_parent);
        _objectPool.Add(recycleObject);
    }
}
