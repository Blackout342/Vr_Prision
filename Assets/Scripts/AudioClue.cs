using UnityEngine;

public class AudioClue : MonoBehaviour
{
    public AudioClip soundToPlay;
    public float volume = 60f;

    private void OnTriggerEnter(Collider other)
    {
        /* if (!string.IsNullOrEmpty(targetTag) && !other.CompareTag(targetTag))
        {
            return;
        }*/

        SFXManager.Instance.PlaySound3D(soundToPlay, transform.position, volume);
        
    }
}