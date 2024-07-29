using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : Singleton<LevelUp>
{
    [SerializeField] GameObject _tempObject;
    SelectBox[] _selectBoxs;
    SelectBoxType _dronBox;
    SelectBoxType _electrodeBox;
    SelectBoxType _fjorginBox;
    SelectBoxType _mk2Box;
    SelectBoxType _ninjaStarBox;
    SelectBoxType _thunderBox;
    SelectBoxType _donePieceBox;
    SelectBoxType _atropineBox;
    SelectBoxType _emergencyBox;
    SelectBoxType _healPotionBox;

    RectTransform _rectTransform;

    public void Show()
    {
        _rectTransform.localScale = Vector3.one;
        GameManager.Instance.Stop();
    }

    public void Hide()
    {
        _rectTransform.localScale = Vector3.zero;
        GameManager.Instance.Resume();
    }

    //public void Batch()
    //{
    //    _dronBox.transform.SetParent(_selectBoxs[1].transform);
    //    _dronBox.transform.localScale = Vector3.one;
    //    _dronBox.transform.localPosition = Vector3.zero;
    //    Test();
    //}

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _selectBoxs = GetComponentsInChildren<SelectBox>();
        InitializeSelectBox();
    }

    void InitializeSelectBox()
    {
        _dronBox = Instantiate(GameResourcesManager.Instance.DronBox());
        _dronBox.transform.SetParent(_tempObject.transform);
        _electrodeBox = Instantiate(GameResourcesManager.Instance.ElectrodeBox());
        _electrodeBox.transform.SetParent(_tempObject.transform);
        _fjorginBox = Instantiate(GameResourcesManager.Instance.FjorginBox());
        _fjorginBox.transform.SetParent(_tempObject.transform);
        _mk2Box = Instantiate(GameResourcesManager.Instance.Mk2Box());
        _mk2Box.transform.SetParent(_tempObject.transform);
        _ninjaStarBox = Instantiate(GameResourcesManager.Instance.NinjaStarBox());
        _ninjaStarBox.transform.SetParent(_tempObject.transform);
        _thunderBox = Instantiate(GameResourcesManager.Instance.ThunderBox());
        _thunderBox.transform.SetParent(_tempObject.transform);
        _donePieceBox = Instantiate(GameResourcesManager.Instance.DonePieceBox());
        _donePieceBox.transform.SetParent(_tempObject.transform);
        _atropineBox = Instantiate(GameResourcesManager.Instance.AtropineBox());
        _atropineBox.transform.SetParent(_tempObject.transform);
        _emergencyBox = Instantiate(GameResourcesManager.Instance.EmergencyBox());
        _emergencyBox.transform.SetParent(_tempObject.transform);
        _healPotionBox = Instantiate(GameResourcesManager.Instance.HealPotionBox());
        _healPotionBox.transform.SetParent(_tempObject.transform);
    }

    int RandomItem()
    {
        int randomNumber = Random.Range(0, 7);
        switch (randomNumber)
        {
            case 0:
                return randomNumber;
            case 1:
                return randomNumber;
            case 2:
                return randomNumber;
            case 3:
                return randomNumber;
            case 4:
                return randomNumber;
            case 5:
                return randomNumber;
            case 6:
                return randomNumber;

            default:
                return randomNumber;
        }
    }

    void Test()
    {
        int a = RandomItem();
        int b = RandomItem();
        int c = RandomItem();

        while (true)
        {
            if (a == b)
            {
                b = RandomItem();
            }

            else if (a == c)
            {
                c = RandomItem();
            }

            else if (b == c)
            {
                c = RandomItem();
            }
            else
            {
                print(a);
                print(b);
                print(c);
                break;
            }
        }
    }
}
