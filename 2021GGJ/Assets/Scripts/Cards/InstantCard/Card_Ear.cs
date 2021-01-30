using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEar", menuName = "Cards/Instant/Ear")]
public class Card_Ear : InstantCardObject
{
    public override void OnUse()
    {
        MusicManager.GetInstance().OnUseEar();
    }
}
