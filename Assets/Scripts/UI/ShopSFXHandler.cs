using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSFXHandler : MonoBehaviour
{
    public static ShopSFXHandler instance;

    public AudioSource[] audio;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        audio = GetComponents<AudioSource>();
    }
    public void PlayErrorAudio() {
        audio[0].Play();
    }

    public void PlayPurchaseAudio() {
        audio[1].Play();
    }
    public void PlayRerollAudio()
    {
        audio[2].Play();
    }
}
