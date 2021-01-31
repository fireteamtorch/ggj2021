using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    public bool isBGMSetToHeaderLoop;
    public bool isBGMOnHeader;
    private AudioClip audioClipToLoop;

    private AudioSource[] audioSrcArr;

    private int audioSrcIndex;

    private void Awake()
    {
        audioSrcArr = this.GetComponents<AudioSource>();
        audioSrcIndex = 1;
    }
    
    public void PlaySFX()
    {

    }

    public void Update()
    {
        if (isBGMSetToHeaderLoop)
        {
            if(audioSrcArr[0].isPlaying == false && isBGMOnHeader)
            {
                audioSrcArr[0].clip = audioClipToLoop;
                audioSrcArr[0].loop = true;
                audioSrcArr[0].Play();
            }
        }
    }

    public void PlayHeaderLoop(AudioClip header, AudioClip loop)
    {
        audioSrcArr[0].clip = header;
        audioSrcArr[0].loop = false;
        audioSrcArr[0].Play();
        audioClipToLoop = loop;
        isBGMOnHeader = true;
        isBGMSetToHeaderLoop = true;
    }

    public void SetBGMVolume(float aVolume)
    {
        audioSrcArr[0].volume = aVolume;
    }

}
