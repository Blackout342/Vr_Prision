using UnityEngine;
// Es necesario importar la librería del nuevo Input System
using UnityEngine.InputSystem; 

public class MouseTester : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Nueva forma de detectar el clic izquierdo del ratón
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Nueva forma de obtener la posición del ratón en pantalla
            Vector2 mousePosition = Mouse.current.position.ReadValue();

            // Creamos el rayo desde la posición obtenida hacia el mundo 3D
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Button button = hit.collider.GetComponent<Button>();

                if (button != null)
                {
                    Debug.Log($"[Prueba Ratón] Clic en el objeto: {hit.collider.name}");
                    
                    // Ejecuta la lógica del botón directamente
                    button.sequenceSystem.PressButton(button.buttonID);
                }
            }
        }
    }
}