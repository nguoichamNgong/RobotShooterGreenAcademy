using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip background; //
    public AudioClip death; //
    public AudioClip pistonGun;
    public AudioClip machineGun;
    public AudioClip sniper;
    public AudioClip Robot;
    public AudioClip gun;
    public AudioClip enemiDeath;
    public AudioClip Win;
    public AudioClip Lose; //
    public AudioClip Hit; //
    public AudioClip HD; 
    public AudioClip Jump; //

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void StopSFX(AudioClip clip)
    {
        if (SFXSource.clip == clip && SFXSource.isPlaying)
        {
            SFXSource.Stop();
        }
    }
}
