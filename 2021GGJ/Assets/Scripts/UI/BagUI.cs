using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagUI : MonoBehaviour
{
    public List<CardObjectUI> cardUIs;
    public Text nameText;
    public Text durabilityText;
    public Text descriptionText;
    public Image organImg;

    public Button useButton;
    public Button dropButton;

    private static BagUI instance;

    public CardObject currentCard;

    public static BagUI GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void SetDatas(List<CardObject> cards)
    {
        RefreshAll();
        for (int i = 0; i < cards.Count; i++)
        {
            cardUIs[i].SetData(cards[i]);
        }
        RefreshDescription();
    }

    public void SetDescription(CardObject card)
    {
        if (card == null)
        {
            RefreshDescription();
            return;
        }

        currentCard = card;
        nameText.text = card.cardName;
        durabilityText.text = card.GetValueString();
        descriptionText.text = card.cardDescription;
        organImg.sprite = card.cardTexture;
        organImg.gameObject.SetActive(true);
        ResetButton();
        dropButton.gameObject.SetActive(true);
        if (card.IsUseable)
            useButton.gameObject.SetActive(true);
    }

    public void RefreshDescription()
    {
        currentCard = null;
        nameText.text = string.Empty;
        durabilityText.text = string.Empty;
        descriptionText.text = string.Empty;
        organImg.gameObject.SetActive(false);
        ResetButton();
    }

    public void ResetButton()
    {
        useButton.gameObject.SetActive(false);
        dropButton.gameObject.SetActive(false);
    }

    public void RefreshAll()
    {
        foreach(var co in cardUIs)
        {
            co.Refresh();
        }
    }

    private void Update()
    {
        durabilityText.gameObject.SetActive(GameManager.GetInstance().noseBuff);
    }

    public void OnClick_Back()
    {
        this.gameObject.SetActive(false);
    }

    public void OnClick_Drop()
    {
        if (currentCard == null)
            return;
        GameManager.GetInstance().ownCards.Remove(currentCard);
        GameManager.GetInstance().Refresh();
    }

    public void OnClick_Use()
    {
        currentCard.OnUse();
        GameManager.GetInstance().Refresh();

    }

}
