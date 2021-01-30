using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageUI : MonoBehaviour
{
    public Text msgText;
    public void SetData(string msg)
    {
        msgText.text = msg;
        this.gameObject.SetActive(true);
    }
}
