using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCutSceneAudioBehavior : MonoBehaviour
{
    public AudioClip audioClip; // Assign your audio clip in the Inspector
    private AudioSource Click;
    [SerializeField] private int Count;

    [SerializeField] private int paragraphCount;



    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        Click = GetComponents<AudioSource>()[1];

        // Assign the audio clip to the AudioSource
        Click.clip = audioClip;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && (Count < (paragraphCount - 1)))
        {
            {
                // Play the assigned audio clip
                if (Click.clip != null)
                {
                    Click.Play();
                    Count++;

                }
            }
        }
    }
}
