using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    public Text storyText;
    public Sprite startSprite;
    public List<string> stories;
    public List<Sprite> textures;
    public GameObject titleText;
    public GameObject buttons;

    public GameObject BackGround;

    public Image brainImg;

    public int currentStoryIndex = 0;

    public void OnClick_Play()
    {
        titleText.SetActive(false);
        

        

        currentStoryIndex = 0;
        storyText.gameObject.SetActive(true);

        storyText.text = stories[currentStoryIndex];
        brainImg.sprite = textures[currentStoryIndex];

        BackGround.SetActive(true);
        buttons.SetActive(false);
    }

    public void ResetAll()
    {
        brainImg.sprite = startSprite;
        storyText.gameObject.SetActive(false);
        titleText.SetActive(true);
        buttons.SetActive(true);
        currentStoryIndex = 0;
        BackGround.SetActive(false);
    }

    public void OnClick_Next()
    {
        currentStoryIndex++;
        if (currentStoryIndex >= stories.Count)
        {
            GameManager.GetInstance().ResetAll();
            this.gameObject.SetActive(false);
            GameManager.GetInstance().LogMessage("點擊中間的容器，尋找可用的東西！\n（如果無計可施，可以在左下角重新開始）");
            return;
        }
        storyText.text = stories[currentStoryIndex];
        brainImg.sprite = textures[currentStoryIndex];
    }



}
