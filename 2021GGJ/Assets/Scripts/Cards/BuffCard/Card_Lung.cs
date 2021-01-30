using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLung", menuName = "Cards/Buff/Lung")]
public class Card_Lung : BuffCardObject
{
    public float lungRate = 0.1f;
    public int durabilityLoss = 5;

    public override void OnMove()
    {
        ChangeDurability(-durabilityLoss);
    }

    public override void OnGetOrgan()
    {
        ChangeDurability(-durabilityLoss);
    }

}
