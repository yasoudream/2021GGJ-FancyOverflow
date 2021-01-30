using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewMoth", menuName = "Cards/Monster/Moth")]
public class Card_Moth : MonsterCard
{
    public override void MonsterEffect()
    {
        GameManager gm = GameManager.GetInstance();
        if (gm.ownCards.Count <= 0)
            return;

        gm.ownCards[Random.Range(0, gm.ownCards.Count)].ChangeDurability(-1000);
    }
}
