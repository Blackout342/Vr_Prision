using UnityEngine;

public class Button : MonoBehaviour
{
    public SequenceTrigger sequenceSystem;
    public int buttonID;

    private bool canPress = true;
    public float resetDelay = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (canPress && (other.CompareTag("Player") || other.name.Contains("Hand") || other.name.Contains("Controller")))
        {
            canPress = false;
            SFXManager.Instance.PlaySound3D(SFXManager.Instance.buttonPressClip, transform.position, 0.6f);
            if (sequenceSystem != null)
            {
                sequenceSystem.PressButton(buttonID);
            }

            transform.localPosition -= new Vector3(0, 0, 0.05f); 
            
            Invoke(nameof(ResetButton), resetDelay);
        }
    }

    private void ResetButton()
    {
        transform.localPosition += new Vector3(0, 0, 0.05f);
        canPress = true;
    }
}