using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAudioBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    public static BattleAudioBehavior Instance;
    private AudioSource audioSource;

    public AudioClip[] SonAttack;
    public AudioClip[] GPAttack;
    public AudioClip[] Damage;
    public AudioClip[] Block;
    public AudioClip[] Footsteps;
    public AudioClip[] ShieldOut;
  

    [SerializeField] public AudioClip ScoreHit;
    [SerializeField] public AudioClip Special;
    [SerializeField] public AudioClip Jump;
    [SerializeField] public AudioClip Land;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(Instance);
        else
            Instance = this;

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    PlayRandomAudioFromArray(SonAttack);
        //}
    }

    public void PlayRandomAudioFromArray(AudioClip[] audioClips)
    {
        if (audioClips != null && audioClips.Length > 0)
        {
            int randomIndex = Random.Range(0, audioClips.Length);
            AudioClip randomClip = audioClips[randomIndex];

            if (randomClip != null)
            {
                audioSource.PlayOneShot(randomClip);
            }
        }
    }
}
