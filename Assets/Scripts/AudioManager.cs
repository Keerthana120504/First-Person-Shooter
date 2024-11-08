using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Private
    [Header("----------- Audio Sources -----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    // Public
    [Header("---------- Audio Clips For Player ----------")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip Shooting;
    public AudioClip Reloading;
    public AudioClip hurt;
    public AudioClip killComfirmed;
    public AudioClip wellDone;
    public AudioClip AmmoPickup;

    [Header("---------- Audio Clips For Zombie ----------")]
    public AudioClip zombieAttack;
 
    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        
            SFXSource.PlayOneShot(clip);
        
    }
    public void chkPlaySFX(AudioClip clip)
    {
        if (!SFXSource.isPlaying)
        {
            SFXSource.PlayOneShot(clip);
        }
    }
}
