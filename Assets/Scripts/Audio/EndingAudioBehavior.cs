using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingAudioBehavior : MonoBehaviour
{
    public static EndingAudioBehavior Instance;
    AudioSource audioSource;


    public AudioClip Victory; // Assign the first audio clip in the Inspector
    public AudioClip Loss; // Assign the second audio clip in the Inspector


    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(Instance);
        else
            Instance = this;

    }

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

    }

    public void PlayAudio (AudioClip audioClip)
    {
  

        // Play the random audio clip as a one-shot
        audioSource.PlayOneShot(audioClip);

    }

}
