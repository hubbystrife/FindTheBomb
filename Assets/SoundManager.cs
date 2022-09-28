using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip uiBtn;
    public AudioClip swordatk;

    private AudioSource audio;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        audio = GetComponent<AudioSource>();
    }

    public void UIClicksfx()
    {
        audio.PlayOneShot(uiBtn);
    }
    public void Sword()
    {
        audio.PlayOneShot(swordatk);
    }
}
