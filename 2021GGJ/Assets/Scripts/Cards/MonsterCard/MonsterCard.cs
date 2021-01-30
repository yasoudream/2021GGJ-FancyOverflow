using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterCard : CardObject
{
    public override void OnUse()
    {
        MonsterEffect();
    }

    public virtual void MonsterEffect()
    {

    }
}
