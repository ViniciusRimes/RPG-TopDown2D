using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    [SerializeField] private AudioClip BGMMusic;
    // Start is called before the first frame update

    private AudioManager audioManager;
    
    void Start()
    {
       audioManager = FindObjectOfType<AudioManager>();

       audioManager.PlayBGM(BGMMusic);
    }

    
}
