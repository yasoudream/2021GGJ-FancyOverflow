using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConsumeBuffType
{
    Eye,
    Nose,
    Heart
}

[CreateAssetMenu(fileName = "NewConsumeCard", menuName = "Cards/ConsumeCard")]
public class ConsumeCardObject : CardObject
{
    public ConsumeBuffType buffType;

    public bool UseState;
    
    public void Use()
    {
        if (UseState)
            return;

        UseState = true;
        IsUseable = false;
    }

    public override void OnUse()
    {
        Use();
    }

}
