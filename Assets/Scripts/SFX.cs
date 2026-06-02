using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;
    public AudioClip keySuccessClip, wrongKeyClip, buttonPressClip, doorOpenClip;
    public AudioSource globalAudioSource;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        globalAudioSource = gameObject.AddComponent<AudioSource>();
    
    }

    public void PlaySound2D(AudioClip clip, float volume = 1f)
    {
        if (clip == null) return;
        globalAudioSource.PlayOneShot(clip, volume);
    }

    public void PlaySound3D(AudioClip clip, Vector3 position, float volume = 1f, float maxDistance = 15f)
    {
        if (clip == null) return;

        GameObject tempAudioObj = new GameObject("TempAudio3D");
        tempAudioObj.transform.position = position;

        AudioSource audioSource = tempAudioObj.AddComponent<AudioSource>();
        
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.spatialBlend = 1.0f;
        audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
        audioSource.minDistance = 1f;
        audioSource.maxDistance = maxDistance;
        audioSource.spatialize = true; 
        audioSource.Play();

        Destroy(tempAudioObj, clip.length);
    }
}