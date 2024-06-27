using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillUI : MonoBehaviour
{
    Text _myText;
    void Awake()
    {
        _myText = GetComponent<Text>();
    }

    public void UpdateKillUI(int kill)
    {
        _myText.text = $"{kill}";
    }
}
