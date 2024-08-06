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
    WaitForSeconds _loadWait;
    bool _isAble;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _selectBoxs = GetComponentsInChildren<SelectBox>();
        InitializeSelectBox();
        _isAble = true;
    }

    public void Show()
    {
        _showCoHandle = StartCoroutine(ShowCo());
    }

    public void Hide()
    {
        _rectTransform.localScale = Vector3.zero;
        Recover();
        GameManager.Instance.Resume();
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

    SelectBoxType RandomItem()
    {
        int randomNumber = Random.Range(0, 6);
        switch (randomNumber)
        {
            case 0:
                return _dronBox;
            case 1:
                return _electrodeBox;
            case 2:
                return _fjorginBox;
            case 3:
                return _mk2Box;
            case 4:
                return _ninjaStarBox;
            case 5:
                return _thunderBox;
            default:
                return _emergencyBox;
        }
    }

    void UIBatch()
    {
        _isAble = false;
        while (true)
        {
            SelectBoxType selectA = RandomItem();
            SelectBoxType selectB = RandomItem();
            SelectBoxType selectC = RandomItem();

            if (selectA != selectB && selectA != selectC && selectB != selectC)
            {
                BoxSetting(selectA, _selectBoxs[0].transform);
                BoxSetting(selectB, _selectBoxs[1].transform);
                BoxSetting(selectC, _selectBoxs[2].transform);
                break;
            }
        }
    }

    void BoxSetting(SelectBoxType selectBoxType, Transform transform)
    {
        selectBoxType.transform.SetParent(transform);
        selectBoxType.transform.localPosition = Vector3.zero;
        selectBoxType.transform.localScale = Vector3.one;

    }

    void Recover()
    {
        for (int i = 0; i < _selectBoxs.Length; i++)
        {
            SelectBoxType recoveBox = _selectBoxs[i].GetComponentInChildren<SelectBoxType>();
            recoveBox.transform.SetParent(_tempObject.transform);
        }
        _isAble = true;
    }

    Coroutine _showCoHandle;
    IEnumerator ShowCo()
    {
        if(!_isAble)
        {
            yield return new WaitUntil(() => _isAble);
        }
        UIBatch();
        yield return _loadWait;
        _rectTransform.localScale = Vector3.one;
        GameManager.Instance.Stop();
    }
}
