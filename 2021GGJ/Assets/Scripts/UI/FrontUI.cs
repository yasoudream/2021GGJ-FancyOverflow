using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrontUI : MonoBehaviour
{
    public Image EyeIron;
    public Image NoseIron;
    public Image HeartIron;
    
    public Button nextButton;
    public Button backButton;

    public Text distanceText;

    public void SetDistance(int dis)
    {
        distanceText.text = dis.ToString();
    }

    public void SetNextButton(bool state)
    {
        nextButton.interactable = state;
    }

    public void SetBackButton(bool state)
    {
        backButton.interactable = state;
    }

    public void ResetMoveButton()
    {
        backButton.interactable = true;
        nextButton.interactable = true;
    }

    public void LockMoveButton()
    {
        backButton.interactable = false;
        nextButton.interactable = false;
    }

    public void SetBuffs(bool eye, bool nose, bool heart)
    {
        EyeIron.gameObject.SetActive(eye);
        NoseIron.gameObject.SetActive(nose);
        HeartIron.gameObject.SetActive(heart);
    }
}
