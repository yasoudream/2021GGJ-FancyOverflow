using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject quitButtonObj;
    public GameObject resetButtonObj;
    public GameObject closeButtonObj;
    public GameObject quitMenuBlock;

    public List<CardObject> startList;

    public LibsUI libsui;

    public void OnClick_Quit()
    {
        Application.Quit();
    }

    public void ResetAll()
    {
        OnClick_CloseQuitButton();

        cardLibs.Clear();
        for (int i = 0; i < LibCount; i++)
        {
            List<CardObject> lib = new List<CardObject>();
            foreach (var c in cards)
            {
                if (GetCardCreate(c.cardRate))
                {
                    lib.Add(c.Create());
                }
            }
            foreach (var m in monsters)
            {
                if (GetCardCreate(m.cardRate))
                {
                    lib.Add(m.Create());
                }
            }
            cardLibs.Add(lib);
        }
        ownCards.Clear();
        foreach (var c in startList)
        {
            ownCards.Add(Instantiate(c));
        }
        libsui.Check();
        currentLibIndex = 0;
        Refresh();
        frontUI.SetDistance(LibCount);
    }

    public void OnClick_Reset()
    {
        ResetAll();
    }

    public void OnClick_CloseQuitButton()
    {
        quitButtonObj.SetActive(false);
        resetButtonObj.SetActive(false);
        closeButtonObj.SetActive(false);
        quitMenuBlock.SetActive(false);
    }

    public void OnClick_QuitMenu()
    {
        quitButtonObj.SetActive(true);
        resetButtonObj.SetActive(true);
        closeButtonObj.SetActive(true);
        quitMenuBlock.SetActive(true);
    }



    private static GameManager instance;
    public static GameManager GetInstance()
    {
        return instance;
    }
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public List<CardObject> cards;
    public List<MonsterCard> monsters;
    public List<CardObject> ownCards = new List<CardObject>();
    public List<List<CardObject>> cardLibs = new List<List<CardObject>>();
    public int currentLibIndex = 0;

    public int LibCount = 50;
    public int BagCount = 9;


    public int GetCardCount = 0;
    public int GetCardCount_AfterBuff = 0;
    public int MoveSpeed = 0;
    public int MoveSpeed_AfterBuff = 0;
    public int handcount = 0;
    public int legcount = 0;

    public float lungRate = 0;

    public bool eyeBuff = false;
    public bool noseBuff = false;
    public bool heartBuff = false;

    private bool GetCardCreate(int rate)
    {
        int r = Random.Range(0, 100);
        return r < rate;
    }

    private void Start()
    {
        ResetAll();
    }

    public void Refresh()
    {
        handcount = 0;
        legcount = 0;
        lungRate = 0;
        eyeBuff = noseBuff = heartBuff = false;
        foreach (var c in ownCards)
        {
            switch(c.cardType)
            {
                case CardType.Buff:
                    switch((c as BuffCardObject).buffType)
                    {
                        case BuffType.Hand:
                            handcount++;
                            break;
                        case BuffType.Leg:
                            legcount++;
                            break;
                        case BuffType.Lung:
                            lungRate += (c as Card_Lung).lungRate;
                            break;
                    }
                    break;
                case CardType.Consume:
                    if ((c as ConsumeCardObject).UseState)
                        switch ((c as ConsumeCardObject).buffType)
                        {
                            case ConsumeBuffType.Eye:
                                eyeBuff = true;
                                break;
                            case ConsumeBuffType.Nose:
                                noseBuff = true;
                                break;
                            case ConsumeBuffType.Heart:
                                heartBuff = true;
                                break;
                        }
                    break;
            }
        }
        GetCardCount_AfterBuff = GetCardCount + handcount;
        MoveSpeed_AfterBuff = MoveSpeed + legcount;
        CheckIndex();
        bagui.SetDatas(ownCards);
        libsui.Check();
        frontUI.SetBuffs(eyeBuff, noseBuff, heartBuff);
        frontUI.SetDistance(LibCount - currentLibIndex);
    }

    public BagUI bagui;

    public void DecayListenner(CardObject card)
    {
        ownCards.Remove(card);
        
        Refresh();
        
    }

    public FrontUI frontUI;
    
    public void OnClick_Next()
    {
        Card_Leg c = ownCards.Find(x => x.cardType == CardType.Buff && (x as BuffCardObject).buffType == BuffType.Leg) as Card_Leg;
        if (c == null)
        {
            LogMessage("沒有脚了，已經寸步難行了");
        }
        else
        {
            if (currentLibIndex < LibCount)
            {
                libsui.OnClick_Left();
                currentLibIndex++;
            }
            
            
            if (currentLibIndex < LibCount)
            {
                c.OnMove();
                MoveTrigger();
                Refresh();
            }
            else
            {
                GameOver();
            }
        }
        
    }

    public FinalManager fm;
    public void GameOver()
    {
        fm.SetFinal();
        fm.gameObject.SetActive(true);
    }

    public CardObject GetRandomCard(int durability)
    {
        var c = cards[Random.Range(0, cards.Count)].Create();
        c.durabilityValue = durability;
        return c;
    }

    public void OnClick_Back()
    {
        CardObject c = ownCards.Find(x => x.cardType == CardType.Buff && (x as BuffCardObject).buffType == BuffType.Leg);
        if (c == null)
        {
            LogMessage("沒有脚了，已經寸步難行了");
        }
        else
        {
            libsui.OnClick_Right();
            c.OnMove();
            MoveTrigger();
            currentLibIndex--;
            Refresh();
            
        }


    }

    public void MoveTrigger()
    {
        List<CardObject> cs = new List<CardObject>();
        foreach (var c in ownCards)
        {
            if (c.cardType != CardType.Buff)
                cs.Add(c);
        }

        foreach (var c in cs)
        {
            c.OnMove();
        }
    }

    public void CheckIndex()
    {
        frontUI.ResetMoveButton(); 
        //CardObject c = ownCards.Find(x => x.cardType == CardType.Buff && (x as BuffCardObject).buffType == BuffType.Leg);
        //if (c == null)
        //{
        //    frontUI.LockMoveButton();
        //    return;
        //}
        if (currentLibIndex <= 0)
            frontUI.SetBackButton(false);
        //if (currentLibIndex >= LibCount - 1)
        //    frontUI.SetNextButton(false);
    }

    public void GetOrganTrigger()
    {
        List<CardObject> cs = new List<CardObject>();
        foreach (var c in ownCards)
        {
            if (c.cardType != CardType.Buff || (c as BuffCardObject).buffType == BuffType.Lung)
                cs.Add(c);
        }

        foreach (var c in cs)
        {
            c.OnGetOrgan();
        }
    }

    public void LookCardTrigger()
    {
        List<CardObject> cs = new List<CardObject>();
        foreach (var c in ownCards)
        {
            cs.Add(c);
        }

        foreach (var c in cs)
        {
            c.OnLookOrgan();
        }
    }

    public void HandTrigger()
    {
        CardObject c = ownCards.Find(x => x.cardType == CardType.Buff && (x as BuffCardObject).buffType == BuffType.Hand);
        c.OnGetOrgan();
    }

    public void GetCard(CardObject c)
    {
        ownCards.Add(c);
        cardLibs[currentLibIndex].Remove(c);
        Refresh();
    }



    public bool UseHeart(int value)
    {
        CardObject cobj = ownCards.Find(x => x.cardType == CardType.Consume && (x as ConsumeCardObject).buffType == ConsumeBuffType.Heart && (x as ConsumeCardObject).UseState == true);
        if (cobj != null)
        {
            cobj.ChangeDurability(value);
            return true;
        }
        return false;
    }

    public Sprite usefulSprite;
    public Sprite decaySprite;
    public Sprite nothingSprite;

    public void OnClick_Bag()
    {
        Refresh();
        bagui.SetDatas(ownCards);
        bagui.gameObject.SetActive(true);
    }

    public MessageUI msgui;
    public void LogMessage(string msg)
    {
        msgui.SetData(msg);
    }

}
