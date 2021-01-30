using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBrain", menuName = "Cards/Instant/Brain")]
public class Card_Brain : InstantCardObject
{
    public float brainRate = 0.5f;

    public override void OnUse()
    {
        int h = (int)(brainRate * durabilityValue);
        foreach (var c in GameManager.GetInstance().ownCards)
        {
            c.ChangeDurability(h);
        }
        this.ChangeDurability(-101);
    }
}
