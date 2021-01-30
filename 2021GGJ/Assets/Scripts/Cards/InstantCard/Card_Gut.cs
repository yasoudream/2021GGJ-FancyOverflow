using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGut", menuName = "Cards/Instant/Gut")]
public class Card_Gut : InstantCardObject
{
    public float gutRate = 1f;

    public override void OnUse()
    {
        int h = (int)(gutRate * durabilityValue);
        this.ChangeDurability(-101);
        GameManager gm = GameManager.GetInstance();
        gm.GetCard(gm.GetRandomCard(h));
    }
}
