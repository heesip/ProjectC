//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AchiveManager : MonoBehaviour
//{
//    public GameObject[] lockCharacter;
//    public GameObject[] unlockCharacter;
//    public GameObject uiNotice;
//    enum Achive
//    {
//        UmlockPotato,
//        UnlockBean,
//    }

//    Achive[] achives;

//    WaitForSecondsRealtime wait;

//    private void Awake()
//    {
//        achives = (Achive[])Enum.GetValues(typeof(Achive));
//        wait = new WaitForSecondsRealtime(5f);
//        if (!PlayerPrefs.HasKey("MyData"))
//        {
//            Init();
//        }
//    }


//    void Init()
//    {
//        PlayerPrefs.SetInt("MyData", 1);

//        foreach (var achive in achives)
//        {
//            PlayerPrefs.SetInt(achive.ToString(), 0);
//        }
//    }

//    private void Start()
//    {
//        UnlockCharacter();
//    }

//    void UnlockCharacter()
//    {
//        for (int i = 0; i < lockCharacter.Length; i++)
//        {
//            string achiveName = achives[i].ToString();
//            bool isUnlock = PlayerPrefs.GetInt(achiveName) == 1;

//            lockCharacter[i].SetActive(!isUnlock);
//            unlockCharacter[i].SetActive(isUnlock);
//        }
//    }



//    private void LateUpdate()
//    {
//        foreach (Achive achive in achives)
//        {
//            CheckAchive(achive);
//        }
//    }

//    void CheckAchive(Achive achive)
//    {
//        bool isAchive = false;

//        switch (achive)
//        {
//            case Achive.UmlockPotato:
//                isAchive = GameManager.Instance.kill >= 10;
//                break;
//            case Achive.UnlockBean:
//                isAchive = GameManager.Instance.gameTime == GameManager.Instance.maxGameTime;
//                break;
//            default:
//                break;
//        }
//        if (isAchive && PlayerPrefs.GetInt(achive.ToString()) == 0)
//        {
//            PlayerPrefs.SetInt(achive.ToString(), 1);

//            for (int i = 0; i < uiNotice.transform.childCount; i++)
//            {
//                bool isActive = i == (int)achive;
//                uiNotice.transform.GetChild(i).gameObject.SetActive(isActive);
//            }
//            StartCoroutine(NoticeCo());
//        }
//    }

//    IEnumerator NoticeCo()
//    {

//        uiNotice.SetActive(true);
//        AudioManager.Instance.PlaySfx(AudioManager.Sfx.LevelUP);

//        yield return wait;

//        uiNotice.SetActive(false);
//    }
//}
