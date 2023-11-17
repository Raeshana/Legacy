using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAudioBehavior : MonoBehaviour
{
    //has all the methods to call audio files



    public static WalkAudioBehavior Instance;

    // Footsteps
    public AudioSource audioSource;
    public AudioClip[] audioClips;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAudio()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            // Play the audio
            audioSource.Play();
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
            audioSource.PlayOneShot(randomClip, Random.Range(0.2f, 0.8f));

            // Destroy the AudioSource component after playing the audio
            Destroy(audioSource, randomClip.length + 0.2f); // Adding a small delay before destroying
        }
    }
    void PlaySpecial()
    {
        if (audioClips != null)
        {
            // Create an AudioSource to play the random audio clip
            AudioSource Special = gameObject.AddComponent<AudioSource>();
            Special.playOnAwake = false;

            // Play the random audio clip as a one-shot
            Special.PlayOneShot(BattleAudioBehavior.Instance.Special);

            // Destroy the AudioSource component after playing the audio
            Destroy(Special, BattleAudioBehavior.Instance.Special.length + 0.1f); // Adding a small delay before destroying
        }
    }
    void PlayGPSpecial()
    {
        if (audioClips != null)
        {
            // Create an AudioSource to play the random audio clip
            AudioSource GPSpecial = gameObject.AddComponent<AudioSource>();
            GPSpecial.playOnAwake = false;

            // Play the random audio clip as a one-shot
            GPSpecial.PlayOneShot(BattleAudioBehavior.Instance.GPSpecial);

            // Destroy the AudioSource component after playing the audio
            Destroy(GPSpecial, BattleAudioBehavior.Instance.GPSpecial.length + 0.1f); // Adding a small delay before destroying
        }
    }
    void PlayJump()
    {
        if (audioClips != null)
        {


            // Create an AudioSource to play the random audio clip
            AudioSource Jump = gameObject.AddComponent<AudioSource>();
            Jump.playOnAwake = false;

            // Play the random audio clip as a one-shot
            Jump.PlayOneShot(BattleAudioBehavior.Instance.Jump, Random.Range(0.2f, 0.8f));

            // Destroy the AudioSource component after playing the audio
            Destroy(Jump, 0.1f); // Adding a small delay before destroying
        }
    }
    void PlayLand()
    {
        if (audioClips != null)
        {
            // Create an AudioSource to play the random audio clip
            AudioSource Land = gameObject.AddComponent<AudioSource>();
            Land.playOnAwake = false;

            // Play the random audio clip as a one-shot
            Land.PlayOneShot(BattleAudioBehavior.Instance.Land, Random.Range(0.2f, 0.8f));

            // Destroy the AudioSource component after playing the audio
            Destroy(Land, 0.1f); // Adding a small delay before destroying
        }
    }

    void PlayBlock()
    {
        if (audioClips != null && audioClips.Length > 0)
        {
            // Choose a random audio clip from the array
            AudioClip blockClip = BattleAudioBehavior.Instance.ShieldOut[Random.Range(0, BattleAudioBehavior.Instance.ShieldOut.Length-1)];

            AudioSource Block = gameObject.AddComponent<AudioSource>();
            Block.playOnAwake = false;

            // Play the random audio clip as a one-shot
            Block.PlayOneShot(blockClip, Random.Range(0.2f, 0.8f));

            // Destroy the AudioSource component after playing the audio
            Destroy(audioSource, blockClip.length + 0.1f); // Adding a small delay before destroying
        }
    }

    void PlaySonAttack()
    {
        if (audioClips != null && audioClips.Length > 0)
        {
            // Choose a random audio clip from the array
            AudioClip sonClip = BattleAudioBehavior.Instance.SonAttack[Random.Range(0, BattleAudioBehavior.Instance.SonAttack.Length-1)];

            AudioSource Son = gameObject.AddComponent<AudioSource>();
            Son.playOnAwake = false;

            // Play the random audio clip as a one-shot
            Son.PlayOneShot(sonClip, Random.Range(0.6f, 0.8f));

            // Destroy the AudioSource component after playing the audio
            Destroy(audioSource, sonClip.length + 0.1f); // Adding a small delay before destroying
        }
    }
    public void PlayDamageSon()
    {
        if (audioClips != null && audioClips.Length > 0)
        {
            // Choose a random audio clip from the array
            AudioClip sonDamClip = BattleAudioBehavior.Instance.DamageSon[Random.Range(0, BattleAudioBehavior.Instance.DamageSon.Length - 1)];

            AudioSource SonDam = gameObject.AddComponent<AudioSource>();
            SonDam.playOnAwake = false;

            // Play the random audio clip as a one-shot
            SonDam.PlayOneShot(sonDamClip, Random.Range(0.6f, 0.8f));

            // Destroy the AudioSource component after playing the audio
            Destroy(audioSource, sonDamClip.length + 0.1f); // Adding a small delay before destroying
        }
    }
    public void PlayDamageGP()
    {
        if (audioClips != null && audioClips.Length > 0)
        {
            // Choose a random audio clip from the array
            AudioClip gpDamClip = BattleAudioBehavior.Instance.DamageGP[Random.Range(0, BattleAudioBehavior.Instance.DamageGP.Length - 1)];

            AudioSource GPDam = gameObject.AddComponent<AudioSource>();
            GPDam.playOnAwake = false;

            // Play the random audio clip as a one-shot
            GPDam.PlayOneShot(gpDamClip, Random.Range(0.6f, 0.8f));

            // Destroy the AudioSource component after playing the audio
            Destroy(audioSource, gpDamClip.length + 0.1f); // Adding a small delay before destroying
        }
    }

    void PlayGPAttack()
    {
        if (audioClips != null && audioClips.Length > 0)
        {
            // Choose a random audio clip from the array
            AudioClip GPA = BattleAudioBehavior.Instance.GPAttack[Random.Range(0, BattleAudioBehavior.Instance.GPAttack.Length-1)];

            // Create an AudioSource to play the random audio clip
            AudioSource GPSource = gameObject.AddComponent<AudioSource>();
            GPSource.playOnAwake = false;

            // Play the random audio clip as a one-shot
            GPSource.PlayOneShot(GPA, Random.Range(0.6f, 0.8f));

            // Destroy the AudioSource component after playing the audio
            Destroy(GPSource, GPA.length + 0.1f); // Adding a small delay before destroying
        }
    }
}
