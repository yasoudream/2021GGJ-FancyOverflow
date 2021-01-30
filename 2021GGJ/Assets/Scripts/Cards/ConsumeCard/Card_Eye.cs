using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEyeCard", menuName = "Cards/Eye")]
public class Card_Eye : ConsumeCardObject
{
    public int durabilityLoss;
    public override void OnLookOrgan()
    {
        if (UseState)
            ChangeDurability(-durabilityLoss);
    }
}
