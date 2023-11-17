using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneAudioBehavior : MonoBehaviour
{
    public AudioClip audioClip; // Assign your audio clip in the Inspector
    public AudioClip Sorry;
    private AudioSource Click;
    private bool sorryPlayed = false; // Flag to track if Sorry audio has been played
    [SerializeField] private int Count;
    [SerializeField] public bool audioPlayed = false;

    public int shareCount;

    [SerializeField] private int paragraphCount;



    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        Click = GetComponent<AudioSource>();

        // Assign the audio clip to the AudioSource
        Click.clip = audioClip;
        Count = 0;
    }

    void Update()
    {
        // Check for mouse button click
        // 4 is for 5 paragraphs
        // could be changed to access paragraphs length -1
        shareCount = Count;
        if (CutsceneManager.Instance.paragraphCheck && Input.GetMouseButtonDown(0) && Count < paragraphCount-1)
        {
            {
                // Play the assigned audio clip
                if (Click.clip != null)
                {
                    Click.Play();
                    audioPlayed = true;
                    Count++;
                }
            }
        }
        if (Input.GetMouseButtonDown(0) && Count == 5 && !sorryPlayed)
        {
            CutsceneManager.Instance.typingSpeed = 0.1f;
            PlaySorry();
            sorryPlayed = true; // Set the flag to true after playing Sorry audio
        }
        if (Count == 6)
        {
            CutsceneManager.Instance.typingSpeed = CutsceneManager.Instance.typingDefaultSpeed;
        }
    }

    public void PlaySorry()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        // slow typing down for voiceover
        audioSource.PlayOneShot(Sorry);

        // Destroy the AudioSource component after playing the audio
        //Destroy(audioSource, 0.1f); // Adding a small delay before destroying
    }
}
