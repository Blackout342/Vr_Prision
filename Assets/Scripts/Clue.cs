using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors; 

public class Clue : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
<<<<<<< HEAD
        SFXManager.Instance.globalAudioSource.PlayOneShot(SFXManager.Instance.clue, 0.8f);
=======
        SFXManager.Instance.PlaySound3D(SFXManager.Instance.clue, transform.position, 100f, 15f, true);
>>>>>>> c44ec47 (Second audio source)
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

}
