using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip getcardAudio;
    public AudioSource bgmplayer;
    public AudioSource clipplayer;
    
    
    private static MusicManager instance;
    public static MusicManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void GetCard()
    {
        clipplayer.PlayOneShot(getcardAudio);
    }

    public void OnUseEar()
    {
        bgmplayer.mute = !bgmplayer.mute;
        clipplayer.mute = !clipplayer.mute;
    }


}
