using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNose", menuName = "Cards/Consume/Nose")]
public class Card_Nose : ConsumeCardObject
{
    public int durabilityLoss;
    public override void OnMove()
    {
        if (UseState)
            ChangeDurability(-durabilityLoss);
    }
}
