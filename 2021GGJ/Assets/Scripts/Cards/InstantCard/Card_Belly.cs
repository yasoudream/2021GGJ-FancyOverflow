using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBelly", menuName = "Cards/Instant/Belly")]
public class Card_Belly : InstantCardObject
{
    public float bellyRate = 1;

    public override void OnUse()
    {
        int h = (int)(bellyRate * durabilityValue);
        foreach (var c in GameManager.GetInstance().ownCards)
        {
            c.ChangeDurability(h);
        }
        this.ChangeDurability(-101);
    }
}
