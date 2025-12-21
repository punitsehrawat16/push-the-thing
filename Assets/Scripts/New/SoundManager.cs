using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource playerMove;
    public AudioSource boxPush;
    public AudioSource levelComplete;
    public AudioSource backgroundMusic;
    public AudioSource teleport;
    public AudioSource correctBoxPlacement;
    public AudioSource wallHit;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayPlayerMoveSound()
    {
        playerMove.Play();
    }
    public void PlayBoxPushSound()
    {
        boxPush.Play();
    }
    public void PlayLevelCompleteSound()
    {
        levelComplete.Play();
    }
    public void PlayTeleportSound()
    {
        teleport.Play();
    }
    public void PlayCorrectBoxPlacementSound()
    {
        correctBoxPlacement.Play();
    }
    public void PlayBackgroundMusic()
    {
        if (!backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
    }
    public void StopBackgroundMusic()
    {
        if (backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }
    }
    public void PlayWallHit()
    {
        wallHit.Play();
    }
}
