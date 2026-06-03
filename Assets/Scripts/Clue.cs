using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors; 

public class Clue : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        SFXManager.Instance.globalAudioSource.PlayOneShot(SFXManager.Instance.clue, 0.8f);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

}
