using UnityEngine;

public class KeyLockTrigger : MonoBehaviour
{
    public BaseDoor doorController;
    public int requiredKeyID;

    public bool checkOrder = false;
    public bool checked_; 

    private void OnTriggerEnter(Collider col)
    {
        KeyItem key = col.GetComponent<KeyItem>();
        if (key != null)
        {
            if (!checkOrder)
            {
                if (key.keyID == requiredKeyID)
            {
                doorController.Open();
                Destroy(key.gameObject);
            }
            else
            {
                Debug.Log($"Llave incorrecta");
            }
            }
            else
            {
                if (key.keyID == requiredKeyID && checked_)
            {
                doorController.Open();
                Destroy(key.gameObject);
            }
            else
            {
                Debug.Log($"Llave incorrecta");
            }
            }

        }
    }
}