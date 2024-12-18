using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{

    [SerializeField] private AudioSource footStepSound;
    [SerializeField] private AudioSource backGroundSound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip enemyShoot;
    [SerializeField] private AudioClip impactBody;
    public AudioSource FootStepSound => footStepSound;
    public AudioSource AudioSource => audioSource;

    private void Start()
    {
        LoadComponent();
    }

    private void Reset()
    {
        LoadComponent();
    }

    private void LoadComponent()
    {
        this.LoadFootstepSound();
        this.LoadBGSound();
        audioSource = GetComponent<AudioSource>();
    }

    private void LoadFootstepSound()
    {
        if (this.footStepSound != null) return;
        this.footStepSound = transform.GetChild(1).GetComponent<AudioSource>();
    }

    private void LoadBGSound()
    {
        if (this.backGroundSound != null) return;
        this.backGroundSound = transform.GetChild(0).GetComponent<AudioSource>();
    }

    public void PlayShootSound()
    {
        this.audioSource.PlayOneShot(this.shootSound, 0.5f);
    }

    public void PlayEnemyShootSound()
    {
        this.audioSource.PlayOneShot(this.enemyShoot, 0.5f);
    }

    public void PlayImpactBodySound()
    {
        this.audioSource.PlayOneShot(this.impactBody, 0.5f);
    }
}