using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalManager : MonoBehaviour
{
    public StoryManager sm;
    public List<Sprite> finalSprites;
    public Image finalImg;
    //public int currentIndex;
    public GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    public void SetImg(int index)
    {
        finalImg.sprite = finalSprites[index];
    }

    public void SetFinal()
    {
        if (gm.ownCards.Find(x => (x as Card_Ear) != null))
        {
            SetImg(5);
            return;
        }

        if (gm.ownCards.Find(x => (x as Card_Brain) != null))
        {
            SetImg(4);
            return;
        }

        if (gm.ownCards.Find(x => (x as Card_Belly) != null))
        {
            SetImg(3);
            return;
        }

        if (gm.handcount + gm.legcount <= 4 && gm.handcount > 0 && gm.legcount > 0)
        {
            SetImg(0);
            return;
        }

        if (gm.handcount + gm.legcount > 4 && gm.handcount > 0 && gm.legcount > 0)
        {
            SetImg(1);
            return;
        }

        SetImg(2);

    }

    public void OnClick_Over()
    {
        this.gameObject.SetActive(false);
        gm.ResetAll();
        sm.ResetAll();
        sm.gameObject.SetActive(true);
    }

}
