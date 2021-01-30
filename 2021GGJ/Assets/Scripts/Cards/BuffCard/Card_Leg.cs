using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLeg", menuName = "Cards/Buff/Leg")]
public class Card_Leg : BuffCardObject
{
    public int moveValue = 15;
    
    public override void OnMove()
    {
        if (!GameManager.GetInstance().UseHeart((int)(-moveValue * (1 - GameManager.GetInstance().lungRate))))
            ChangeDurability((int)(-moveValue * (1 - GameManager.GetInstance().lungRate)));
    }

}
