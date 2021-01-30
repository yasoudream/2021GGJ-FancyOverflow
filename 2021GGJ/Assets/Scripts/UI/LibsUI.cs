using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibsUI : MonoBehaviour
{
    public GetOrganUI getorganui;
    public List<LibUIObject> uiObjects;
    public List<RectTransform> poslist;
    public int[] indexlist = new int[5] {0, 1, 2, 3, 4 };

    public List<Sprite> sprites;
    public int currentSpriteIndex = 0;
    public int currentSpriteIndex_back
    {
        get
        {
            return (currentSpriteIndex + 6) % sprites.Count;
        }
    }

    public int currentIndex = 0;

    public float moveRate = 0.1f;

    public GameManager gm;
    public EyeChooseUI eyeui;
    public GetMonsterUI gmui;

    private void Start()
    {
        gm = GameManager.GetInstance();
        Check();
    }

    public void OnClick_GetOrgan()
    {
        if (gm.handcount <= 0)
        {
            gm.LogMessage("已經沒有手了，不能再在容器掏東西了");
            return;
        }
        if (gm.cardLibs[gm.currentLibIndex].Count > 0)
        {
            if (!gm.eyeBuff)
            {
                MusicManager.GetInstance().GetCard();
                gm.HandTrigger();
                gm.GetOrganTrigger();

                CardObject c = gm.cardLibs[gm.currentLibIndex][Random.Range(0, gm.cardLibs[gm.currentLibIndex].Count)];
                if (c.cardType == CardType.Monster)
                {
                    gm.cardLibs[gm.currentLibIndex].Remove(c);
                    gmui.SetData(c);
                }
                else
                {
                    getorganui.SetData(c);
                    getorganui.gameObject.SetActive(true);
                }
                
            }
            else
            {
                gm.LookCardTrigger();
                eyeui.gameObject.SetActive(true);
                eyeui.SetData(gm.cardLibs[gm.currentLibIndex]);
            }
            
        }
        else
        {
            gm.LogMessage("這個容器已經什麽都沒有了QAQ");
        }
    }

    public void GetOrgan_eye(CardObject card)
    {
        eyeui.gameObject.SetActive(false);

        MusicManager.GetInstance().GetCard();

        gm.HandTrigger();
        gm.GetOrganTrigger();

        if (card.cardType == CardType.Monster)
        {
            gm.cardLibs[gm.currentLibIndex].Remove(card);
            gmui.SetData(card);
        }
        else
        {
            getorganui.SetData(card);
            getorganui.gameObject.SetActive(true);
        }
    }

    public void OnClick_Left()
    {
        if (gm.currentLibIndex >= gm.LibCount - 1)
            return;
        for (int i = 0; i < indexlist.Length; i++)
        {
            indexlist[i] = (indexlist[i] + 1) % 5;
            if (indexlist[i] == 0)
            {
                uiObjects[i].SetPos(poslist[0]);
                uiObjects[i].SetImage(sprites[currentSpriteIndex]);
                currentSpriteIndex = (currentSpriteIndex + sprites.Count + 1) % sprites.Count;
                uiObjects[i].SetTarget(poslist[indexlist[i]], moveRate);
            }
            else
            {
                uiObjects[i].SetTarget(poslist[indexlist[i]], moveRate);
            }
        }
        currentIndex++;
        Check();
    }

    public void OnClick_Right()
    {
        if (gm.currentLibIndex <= 0)
            return;
        for (int i = 0; i < indexlist.Length; i++)
        {
            indexlist[i] = (indexlist[i] + 4) % 5;
            if (indexlist[i] == 4)
            {
                uiObjects[i].SetPos(poslist[4]);
                uiObjects[i].SetImage(sprites[currentSpriteIndex_back]);
                currentSpriteIndex = (currentSpriteIndex + sprites.Count - 1) % sprites.Count;
                uiObjects[i].SetTarget(poslist[indexlist[i]], moveRate);
            }
            else
            {
                uiObjects[i].SetTarget(poslist[indexlist[i]], moveRate);
            }
        }
        currentIndex--;
        Check();
    }

    public void Check()
    {
        foreach (var i in uiObjects)
        {
            i.gameObject.SetActive(true);
            i.SetButtonActive(true);
        }

        for (int i = 0; i < 5; i++)
        {
            if (indexlist[i] == 2)
            {
                uiObjects[i].SetButton(true);
            }
            else
            {
                uiObjects[i].SetButton(false);
            }
        }

        if (gm.currentLibIndex == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                if (indexlist[i] == 3)
                {
                    uiObjects[i].SetButtonActive(false);
                    break;
                }
            }
        }
        else if (gm.currentLibIndex == gm.LibCount - 1)
        {
            for (int i = 0; i < 5; i++)
            {
                if (indexlist[i] == 1)
                {
                    uiObjects[i].SetButtonActive(false);
                    break;
                }
            }
        }
    }

    //private void Update()
    //{
    //    for (int i = 0; i < 5; i++)
    //    {
    //        if (indexlist[i] == 2)
    //        {
    //            if (gm.GetCardCount_AfterBuff <= 0)
    //                uiObjects[i].SetButton(false);
    //            else
    //                uiObjects[i].SetButton(true);
    //        }
    //    }
    //}

}
