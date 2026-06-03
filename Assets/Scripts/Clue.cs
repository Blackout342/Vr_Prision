using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors; 

public class Clue : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        SFXManager.Instance.PlaySound3D(SFXManager.Instance.clue, transform.position);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

}
