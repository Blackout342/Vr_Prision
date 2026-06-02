using System.Collections.Generic;
using UnityEngine;

public class SequenceTrigger : MonoBehaviour
{
    public BaseDoor doorController; 
    public List<int> correctSequence = new List<int> { 1, 2, 3, 4 };
    private List<int> currentInput = new List<int>();

    [Header("Recompensa de la Caja Fuerte")]
    // Arrastra aquí la tarjeta/llave que pusiste dentro de la caja
    public GameObject rewardKeyObject; 

    void Start()
    {
        if (rewardKeyObject != null)
        {
            rewardKeyObject.SetActive(false);
        }
    }

    public void PressButton(int buttonID)
    {
        currentInput.Add(buttonID);
        Debug.Log($"Boton: {buttonID}. ({currentInput.Count}/{correctSequence.Count})");

        if (currentInput.Count == correctSequence.Count)
        {
            CheckSequence();
        }
    }

    private void CheckSequence()
    {
        bool isCorrect = true;

        for (int i = 0; i < correctSequence.Count; i++)
        {
            if (currentInput[i] != correctSequence[i])
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            Debug.Log("Secuencia correcta");
            
            if (rewardKeyObject != null)
            {
                rewardKeyObject.SetActive(true);
            }

            if (doorController != null)
            {
                // SFXManager.Instance.PlaySound3D(SFXManager.Instance.doorOpenClip, transform.position);
                doorController.Open();
            }
        }
        else
        {
            // SFXManager.Instance.PlaySound3D(SFXManager.Instance.wrongKeyClip, transform.position);
            Debug.Log("Secuencia incorrecta");
            currentInput.Clear();
        }
    }
}