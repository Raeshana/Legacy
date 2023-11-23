using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAudioBehavior : MonoBehaviour
{
    public AudioClip[] audioClips; // Assign your audio clips in the Inspector

    void Start()
    {
        // Find all buttons in the scene and add a listener to each of them
        Button[] buttons = FindObjectsOfType<Button>();

        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => PlayRandomAudio());
        }
    }

    void PlayRandomAudio()
    {
        if (audioClips != null && audioClips.Length > 0)
        {
            // Choose a random audio clip from the array
            AudioClip randomClip = audioClips[Random.Range(0, audioClips.Length)];

            // Create an AudioSource to play the random audio clip
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;

            // Play the random audio clip as a one-shot
            audioSource.PlayOneShot(randomClip);

            // Destroy the AudioSource component after playing the audio
            Destroy(audioSource, randomClip.length + 0.1f); // Adding a small delay before destroying
        }
    }
}