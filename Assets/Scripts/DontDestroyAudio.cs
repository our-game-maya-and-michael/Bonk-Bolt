using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    private static BackgroundAudio instance = null;

    public AudioClip backgroundClip; // Assign this in the inspector.
    public float volume = 0.1f; // Default volume level. Adjust this value between 0.0 and 1.0

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = backgroundClip;
            audioSource.loop = true; // To loop the background music
            audioSource.volume = volume; // Set the volume
            audioSource.Play();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}