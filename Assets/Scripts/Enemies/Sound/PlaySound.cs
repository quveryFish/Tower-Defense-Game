using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private bool CanStartRandomPlay = true;
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private GameObject deathAudioSourceObject;
    private AudioSource audioSource;
    private void Update()
    {
        if (CanStartRandomPlay && audioClips.Count > 0 && !audioSource.isPlaying)
        {
            PlayRandomSound();
        }
    }

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void DeathSound()
    {
        GameObject deathAUSource = Instantiate(deathAudioSourceObject, transform.position, Quaternion.identity);
        deathAUSource.GetComponent<AudioSource>().PlayOneShot(audioClip);
    }
    public void StopSound()
    {
        audioSource.Stop();
    }
    public void PlaySpecificSound()
    {
        audioSource.PlayOneShot(audioClip);
    }
    public void PlayRandomSound()
    {
        if (audioClips.Count == 0) return;

        AudioClip clip = audioClips[Random.Range(0, audioClips.Count)];
        audioSource.PlayOneShot(clip);
    }
}
