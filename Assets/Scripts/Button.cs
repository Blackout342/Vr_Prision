using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors; 

public class Button : MonoBehaviour
{
    public int buttonID;
    public float resetDelay = 0.5f;
    public SequenceTrigger sequenceSystem;

    private bool canPress = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!canPress) return;

        bool isPlayerHand = other.GetComponent<XRDirectInteractor>() != null;

        if (isPlayerHand)
        {
            canPress = false;

            if (sequenceSystem != null)
            {
                sequenceSystem.PressButton(buttonID);
            }

            transform.localPosition -= new Vector3(0, 0, 0.02f); 
            SFXManager.Instance.PlaySound3D(SFXManager.Instance.buttonPressClip, transform.position, 100f, 15f, true);
            Invoke(nameof(ResetButton), resetDelay);
        }
    }

    private void ResetButton()
    {
        transform.localPosition += new Vector3(0, 0, 0.02f);
        canPress = true;
    }
}