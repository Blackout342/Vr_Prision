using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;
    public AudioClip keySuccessClip, wrongKeyClip, buttonPressClip, doorOpenClip;
    public AudioSource globalAudioSource;
    private AudioSource bgmAudioSource;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        globalAudioSource = gameObject.AddComponent<AudioSource>();
        
        bgmAudioSource = gameObject.AddComponent<AudioSource>();
        bgmAudioSource.loop = true;
        bgmAudioSource.spatialBlend = 0.0f;
    }

    public void PlaySound3D(AudioClip clip, Vector3 position, float volume = 100f, float maxDistance = 15f)
    {
        if (clip == null) return;

        float unityVolume = Mathf.Clamp(volume / 100f, 0f, 1f);

        GameObject tempAudioObj = new GameObject("TempAudio3D");
        tempAudioObj.transform.position = position;

        AudioSource audioSource = tempAudioObj.AddComponent<AudioSource>();
        
        audioSource.clip = clip;
        audioSource.volume = unityVolume;
        audioSource.spatialBlend = 1.0f;
        audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
        audioSource.minDistance = 1f;
        audioSource.maxDistance = maxDistance;
        audioSource.spatialize = true; 
        audioSource.Play();

        Destroy(tempAudioObj, clip.length);
    }

    public void PlayBackgroundMusic(AudioClip clip, float volume = 60f)
    {
        if (clip == null) return;
        if (bgmAudioSource.clip == clip && bgmAudioSource.isPlaying) return;

        float unityVolume = Mathf.Clamp(volume / 100f, 0f, 1f);
        bgmAudioSource.clip = clip;
        bgmAudioSource.volume = unityVolume;
        bgmAudioSource.Play();
    }

    public void StopBackgroundMusic()
    {
        if (bgmAudioSource.isPlaying)
        {
            bgmAudioSource.Stop();
        }
    }
}