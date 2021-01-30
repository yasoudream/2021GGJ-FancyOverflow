using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuffType
{
    Hand,
    Leg,
    Lung
}

[CreateAssetMenu(fileName = "NewBuffCard",menuName = "Cards/BuffCard")]
public class BuffCardObject : CardObject
{
    public BuffType buffType;

}
