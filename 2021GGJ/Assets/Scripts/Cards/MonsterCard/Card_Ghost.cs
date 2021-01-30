using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGhost", menuName = "Cards/Monster/Ghost")]
public class Card_Ghost : MonsterCard
{

    public override void MonsterEffect()
    {
        GameManager gm = GameManager.GetInstance();
        if (gm.ownCards.Count <= 0)
            return;

        foreach (var c in gm.ownCards)
        {
            c.ChangeDurability(-c.durabilityValue / 2);
        }
    }
}
