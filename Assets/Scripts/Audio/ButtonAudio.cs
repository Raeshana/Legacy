using UnityEngine;
using UnityEngine.UI;

public class ButtonAudio : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Get the Button component from this GameObject
        Button button = GetComponent<Button>();

        // Add a listener for when the button is clicked
        button.onClick.AddListener(PlayAudio);
    }

    // Method to play audio when the button is clicked
    void PlayAudio()
    {
        // Check if the AudioSource is assigned and the audio clip is set
        if (audioSource != null && audioSource.clip != null)
        {
            // Play the audio
            audioSource.Play();
        }
    }
}
