using UnityEngine;

public class cupDetector : MonoBehaviour
{
    public KeyLockTrigger lock_;
    public int requiredKeyID;

    private void OnTriggerEnter(Collider col)
    {
        KeyItem key = col.GetComponent<KeyItem>();

        if (key != null)
        {
            if (key.keyID == requiredKeyID)
            {
                lock_.checked_ = true; 
                Destroy(key.gameObject);
            }
            else
            {
                Debug.Log($"Llave incorrecta");
            }
        }
    }
}