using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [SerializeField] private AudioClip[] _music;
    [SerializeField] private AudioClip[] _sfx;



    private AudioSource audioSource;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Get the audio source component on this game object
        audioSource = GetComponent<AudioSource>();
    }

    void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
    
    public void StopSound()
    {
        audioSource.Stop();
    }

    public void PlayMainMusic()
    {
        PlaySound(_music[0]);
    }
    public void PlayGameMusic()
    {
        PlaySound(_music[1]);
    }

    public void PlayJump()
    {
        PlaySFX(0,0.35f);
    }
    
    public void PlayBrake()
    {
        PlaySFX(1,0.35f);
    }
    
    public void PlayHamsterDie()
    {
        PlaySFX(3,0.35f);
        PlaySFX(4,0.35f);
    }
    
    public void PlayTakeMagmnet()
    {
        PlaySFX(5,0.35f);
    }
    
    public void PlayOpenUi()
    {
        PlaySFX(6,0.35f);
    }
    
    public void PlayBackUi()
    {
        PlaySFX(7,0.35f);
    }
    
    public void PlayTakeCoin()
    {
        PlaySFX(2,0.35f);
    }
    
    public void PlayWin()
    {
        PlaySFX(8,0.35f);
        PlaySFX(10,0.3f);

    }
    
    public void PlayChangeCharactor()
    {
        PlaySFX(11,0.3f);
    }
    
    public void PlayOKHEREWEGO()
    {
        PlaySFX(9,0.35f);
    }
    
    public void PlaySFX(int clip,float vol)
    {
        audioSource.PlayOneShot(_sfx[clip],vol);
    }
}