using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBackground : MonoBehaviour
{

    AudioSource ThisAudio;
    bool IsPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        ThisAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAllPlayerPresent() && !IsPlaying) {
            ThisAudio.Play();
            IsPlaying = true;
        }

        if (!IsAllPlayerPresent() && IsPlaying) {
            ThisAudio.Stop();
            IsPlaying = false;
        }
    }

    bool IsAllPlayerPresent() 
    {
        return GameObject.Find("PlayerOne") != null &&
            GameObject.Find("PlayerTwo") != null;
    }
}
