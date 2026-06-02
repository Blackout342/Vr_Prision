using UnityEngine;

public class BaseDoor : MonoBehaviour
{
    public Transform doorMesh;
    public float openAngle = 90f;
    public float openSpeed = 3f;

    private Quaternion closedRotation, openRotation;
    private bool isOpening = false;

    void Start()
    {
        if (doorMesh != null)
        {
            closedRotation = doorMesh.localRotation;
            openRotation = closedRotation * Quaternion.Euler(0, openAngle, 0);
        }
    }

    void Update()
    {
        if (isOpening)
        {
            doorMesh.localRotation = Quaternion.Slerp(doorMesh.localRotation, openRotation, Time.deltaTime * openSpeed);
            if (Quaternion.Angle(doorMesh.localRotation, openRotation) < 0.1f)
            {
                doorMesh.localRotation = openRotation;
                isOpening = false;
            }
        }
    }

    public void Open()
    {
        isOpening = true;
    }
}