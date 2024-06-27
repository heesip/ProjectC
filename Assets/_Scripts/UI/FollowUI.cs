using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FollowUI : MonoBehaviour
{
    RectTransform _rectTransform;

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        _rectTransform.position = Camera.main.WorldToScreenPoint(Player.Instance.transform.position);
    }

}
