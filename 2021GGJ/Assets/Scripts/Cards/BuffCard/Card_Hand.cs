using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHand", menuName = "Cards/Buff/Hand")]
public class Card_Hand : BuffCardObject
{
    public int getOrganValue = 10;

    // Update is called once per frame
    public override void OnGetOrgan()
    {
        if (!GameManager.GetInstance().UseHeart((int)(-getOrganValue *  (1 - GameManager.GetInstance().lungRate))))
            ChangeDurability((int)(-getOrganValue * (1 - GameManager.GetInstance().lungRate)));
    }
}
