using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEgg", menuName = "Cards/Instant/Egg")]
public class Card_Egg : InstantCardObject
{
    public float eggRate = 1.0f;
    public override void OnUse()
    {
        int h = (int)(eggRate * durabilityValue);
        this.ChangeDurability(-101);
        GameManager gm = GameManager.GetInstance();
        var c = gm.ownCards[Random.Range(0, gm.ownCards.Count)];
        var cc = c.Create();
        cc.durabilityValue = h;
        gm.GetCard(cc);

    }
}
