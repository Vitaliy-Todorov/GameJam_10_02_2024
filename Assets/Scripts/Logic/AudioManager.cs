using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] 
    private AudioSource[] _audioSources;

    public void SetValue(float value)
    {
        foreach (AudioSource audioSource in _audioSources) 
            audioSource.volume = value;
    }
    
    public void SetBlend(float value)
    {
        foreach (AudioSource audioSource in _audioSources) 
            audioSource.spatialBlend = 1 - value;
    }
    
    /*public AudioClip[] _sounds;
    public AudioClip[] sounds;

    private AudioSource _audioSource => GetComponent<AudioSource>();

    public void PlaySound(AudioClip clip, float volume = 1f, bool destroyed = false)
    {
        if(destroyed)
            AudioSource.PlayClipAtPoint(clip,transform.position, volume);
        else
            _audioSource.PlayOneShot(clip, volume);
    }*/
}