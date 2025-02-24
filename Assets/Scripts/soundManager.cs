using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager Instance;

    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        
    }

    public void playFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn in gameobject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
    
        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        //get length of soundclip
        float clipLength = audioSource.clip.length;

        //destroy after done playing
        Destroy(audioSource.gameObject, clipLength);
    }
}
