using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookUI : Singleton<BookUI>
{
    [SerializeField] Button[] _itemButton;
    [SerializeField] GameObject[] _itemLock;
    [SerializeField] GameObject[] _itemText;

    [SerializeField] Button _closeButton;
    [SerializeField] GameObject _hiddenObject;
    [SerializeField] Button _hiddenButton;
    [SerializeField] Button _closeButton2;

    
    void UnLock(GameObject lockImage)
    {
        lockImage.SetActive(false);
    }

    void ShowText(GameObject itemText)
    {
        foreach (var item in _itemText)
        {
            item.SetActive(false);
        }
        itemText.SetActive(true);
    }
}
