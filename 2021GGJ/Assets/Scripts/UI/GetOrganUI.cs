using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetOrganUI : MonoBehaviour
{
    public Text nameText;
    public Text descriptionText;
    public Text durabilityText;

    public Image backgroundImg;
    public Image cardImg;

    public Sprite greenBackground;
    public Sprite redBackground;

    public CardObject card;

    public BagUI bagui;

    public void SetData(CardObject card)
    {
        this.card = card;
        nameText.text = card.cardName;
        descriptionText.text = card.cardDescription;
        if (card.IsUseful())
            backgroundImg.sprite = greenBackground;
        else
            backgroundImg.sprite = redBackground;
        durabilityText.text = card.GetValueString();
        cardImg.sprite = card.cardTexture;
    }

    private void Update()
    {
        durabilityText.gameObject.SetActive(GameManager.GetInstance().noseBuff);
    }

    public void OnClick_DropBack()
    {
        this.gameObject.SetActive(false);
    }

    public void OnClick_Get()
    {
        GameManager gm = GameManager.GetInstance();
        
        if (gm.BagCount > gm.ownCards.Count)
        {
            gm.GetCard(card);
            this.gameObject.SetActive(false);
        }
        else
        {
            gm.OnClick_Bag();
            gm.LogMessage("背包滿了 要先丟棄點東西");
        }
    }
}
