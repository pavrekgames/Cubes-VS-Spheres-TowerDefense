using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ExplodeAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip explodeSound;
    void Start()
    {
        audioSource.PlayOneShot(explodeSound);
    }

    
    void Update()
    {
        if(audioSource.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
