using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(UIPrefabResourcesSO), menuName = "ProjectC/Create UIPrefabResourcesSO")]

public class UIPrefabResourcesSO : ScriptableObject
{
    [SerializeField] SelectBoxType _dronBox;
    [SerializeField] SelectBoxType _electrodeBox;
    [SerializeField] SelectBoxType _fjorginBox;
    [SerializeField] SelectBoxType _mk2Box;
    [SerializeField] SelectBoxType _ninjaStarBox;
    [SerializeField] SelectBoxType _thunderBox;
    [SerializeField] SelectBoxType _donePieceBox;
    [SerializeField] SelectBoxType _atropineBox;
    [SerializeField] SelectBoxType _emergencyBox;
    [SerializeField] SelectBoxType _healPotionBox;

    public SelectBoxType DronBox()
    {
        return _dronBox;
    }

    public SelectBoxType ElectrodeBox()
    {
        return _electrodeBox;
    }

    public SelectBoxType FjorginBox()
    {
        return _fjorginBox;
    }

    public SelectBoxType Mk2Box()
    {
        return _mk2Box;
    }

    public SelectBoxType NinjaStarBox()
    {
        return _ninjaStarBox;
    }

    public SelectBoxType ThunderBox()
    {
        return _thunderBox;
    }

    public SelectBoxType DonePieceBox()
    {
        return _donePieceBox;
    }

    public SelectBoxType AtropineBox()
    {
        return _atropineBox;
    }

    public SelectBoxType EmergencyBox()
    {
        return _emergencyBox;
    }

    public SelectBoxType HealPotionBox()
    {
        return _healPotionBox;
    }
}