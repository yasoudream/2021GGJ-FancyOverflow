using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DurabilityType  //耐久值类型
{
    Bout,   //回合
    Percentage  //百分比
}

public enum CardType
{
    Buff,
    Consume,
    Instant,
    Monster
}

public class CardObject : ScriptableObject
{
    #region Durability
    public int durabilityValue;
    public DurabilityType durabilityType;

    public bool IsUseful()
    {
        if (durabilityType == DurabilityType.Percentage)
        {
            return durabilityValue > 30;
        }
        else
        {
            return durabilityValue > 1;
        }
    }
    public string GetValueString()
    {
        if (durabilityType == DurabilityType.Percentage)
            return durabilityValue.ToString() + "%";
        else
            return durabilityValue.ToString() + "回合";
    }
    #endregion Durability
    public string cardName;
    public Sprite cardTexture;
    public CardType cardType;
    public int cardRate = 100;    //稀有度（爆率）
    [TextArea]
    public string cardDescription;

    public CardObject Create()
    {
        CardObject nc = Instantiate(this);
        if (this.durabilityType == DurabilityType.Bout)
        {
            nc.durabilityValue = Random.Range(1, 4);
        }
        else
        {
            nc.durabilityValue = Random.Range(5, 80);
        }
        return nc;
    }

    public virtual void ChangeDurability(int value)
    {
        durabilityValue += value;
        if (durabilityType == DurabilityType.Percentage)
            if (durabilityValue > 100)
                durabilityValue = 100;
        if (durabilityValue <= 0)
            OnDecay();
    }

    public bool IsUseable;

    public virtual void OnDecay()       //耐久归零时
    {
        GameManager.GetInstance().ownCards.Remove(this);
        GameManager.GetInstance().Refresh();
    }

    public virtual void OnMove()
    {

    }

    public virtual void OnGetOrgan()
    {

    }

    public virtual void OnLookOrgan()
    {

    }

    public virtual void OnUse()
    {

    }

}
