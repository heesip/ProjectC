

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBoxType : MonoBehaviour
{
    readonly string _description = "데미지 : {0}\n쿨타임 : {1}초";
    readonly string _description2 = "데미지 : {0}\n크기증가";
    public readonly int MaxLevel = 3;
    [SerializeField] SelectUIType _myType;
    [SerializeField] Text _myText;
    [SerializeField] GameObject[] _levelImages;
    WeaponDataSO _weaponDataSO;

    void Awake()
    {
        _weaponDataSO = GameDataManager.Instance.GetWeaponDataSO();
    }

    public void Test()
    {
        int tempLevel = Level() + 1;
        float tempDamage;
        float tempCoolTime;
        switch (_myType)
        {
            case SelectUIType.Dron:
                tempDamage = _weaponDataSO.DronDamages[tempLevel];
                tempCoolTime = _weaponDataSO.DronCoolTimes[tempLevel];
                _myText.text = string.Format(_description, tempDamage, tempCoolTime);
                break;
            case SelectUIType.Electrode:
                tempDamage = _weaponDataSO.ElectrodeDamage;
                tempCoolTime = _weaponDataSO.ElectrodeCoolTimes[tempLevel];
                _myText.text = string.Format(_description2, tempDamage);
                break;
            case SelectUIType.Mk2:
                tempDamage = _weaponDataSO.Mk2Damage;
                tempCoolTime = _weaponDataSO.Mk2CoolTimes[tempLevel];
                _myText.text = string.Format(_description, tempDamage, tempCoolTime);
                break;
            case SelectUIType.NinjaStar:
            case SelectUIType.DonePiece:
                tempDamage = _weaponDataSO.NinjaStarDamages[tempLevel];
                tempCoolTime = _weaponDataSO.NinjaStarCoolTimes[tempLevel];
                _myText.text = string.Format(_description, tempDamage, tempCoolTime);
                break;
            case SelectUIType.Thunder:
                tempDamage = _weaponDataSO.ThunderDamages[tempLevel];
                tempCoolTime = _weaponDataSO.ThunderCoolTimes[tempLevel];
                _myText.text = string.Format(_description, tempDamage, tempCoolTime);
                break;
            default:
                break;
        }
    }

    public void LevelCheck()
    {
        int nextLevel = Level() - 1;
        if (Level() > 0)
        {
            _levelImages[nextLevel].SetActive(true);
        }
    }

    public void Use()
    {
        switch (_myType)
        {
            case SelectUIType.Dron:
                Dron.Instance.UseWeapon();
                break;
            case SelectUIType.Electrode:
                Electrode.Instance.UseWeapon();
                break;
            case SelectUIType.Fjorgin:
                Fjorgin.Instance.UseWeapon();
                break;
            case SelectUIType.Mk2:
                Mk2.Instance.UseWeapon();
                break;
            case SelectUIType.NinjaStar:
                NinjaStarBox.Instance.UseWeapon();
                break;
            case SelectUIType.Thunder:
                ThunderStroke.Instance.UseWeapon();
                break;
            case SelectUIType.DonePiece:
                NinjaStarBox.Instance.UseWeapon();
                break;
            case SelectUIType.Atropine:
                Player.Instance.Healing(-25, true);
                break;
            case SelectUIType.Emergency:
                Player.Instance.Healing(15, false);
                break;
            case SelectUIType.HealPotion:
                Player.Instance.Healing(30, false);
                break;
            default:
                break;
        }
    }

    public int Level()
    {
        switch (_myType)
        {
            case SelectUIType.Dron:
                return Dron.Instance.Level;
            case SelectUIType.Electrode:
                return Electrode.Instance.Level;
            case SelectUIType.Mk2:
                return Mk2.Instance.Level;
            case SelectUIType.NinjaStar:
            case SelectUIType.DonePiece:
                return NinjaStarBox.Instance.Level;
            case SelectUIType.Thunder:
                return ThunderStroke.Instance.Level;
            default:
                return -100;
        }
    }
}
