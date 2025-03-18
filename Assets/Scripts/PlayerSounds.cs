using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioClip AudioclipPowerUp;
    public AudioClip AudioclipHitMonster;
    public AudioClip AudioclipDie;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    protected void PlayClip(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlayPowerUpSound()
    {
        PlayClip(AudioclipPowerUp);
    }

    public void PlayDieSound()
    {
        PlayClip(AudioclipDie);
    }

    public void PlayHitMonsterSound()
    {
        PlayClip(AudioclipHitMonster);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
