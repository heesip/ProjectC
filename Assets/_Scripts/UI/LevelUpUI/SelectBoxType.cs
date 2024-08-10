

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBoxType : MonoBehaviour
{
    public readonly int MaxLevel = 3;
    [SerializeField] SelectUIType _myType;
    [SerializeField] Text _myText;
    WeaponDataSO _weaponDataSO;

    void Awake()
    {
        _weaponDataSO = GameDataManager.Instance.GetWeaponDataSO();
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
            case SelectUIType.Fjorgin:
                return Fjorgin.Instance.Level;
            case SelectUIType.Mk2:
                return Mk2.Instance.Level;
            case SelectUIType.NinjaStar:
            case SelectUIType.DonePiece:
                return NinjaStarBox.Instance.Level;
            case SelectUIType.Thunder:
                return ThunderStroke.Instance.Level;
            default:
                return 0;
        }
    }

    void UseText()
    {
        switch (_myType)
        {
            case SelectUIType.Dron:
                break;
            case SelectUIType.Electrode:
                break;
            case SelectUIType.Fjorgin:
                break;
            case SelectUIType.Mk2:
                break;
            case SelectUIType.NinjaStar:
                break;
            case SelectUIType.Thunder:
                break;
            case SelectUIType.DonePiece:
                break;
            default:
                return;
        }
    }
}
