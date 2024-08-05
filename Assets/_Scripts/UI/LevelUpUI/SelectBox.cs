using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBox : MonoBehaviour
{
    [SerializeField] Button _myButton;
    SelectBoxType _myBoxType;
    void Start()
    {
        _myButton = GetComponent<Button>();
        _myButton.onClick.AddListener(() => UIClick());
    }

    void UIClick()
    {
        _myBoxType = GetComponentInChildren<SelectBoxType>();
        _myBoxType.Use();
        LevelUp.Instance.Hide();
    }

}
