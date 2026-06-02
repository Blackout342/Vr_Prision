using UnityEngine;

public class KeyLockTrigger : MonoBehaviour
{
    public BaseDoor doorController;
    public int requiredKeyID;

    private void OnTriggerEnter(Collider col)
    {
        KeyItem key = col.GetComponent<KeyItem>();

        if (key != null)
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
    }
}