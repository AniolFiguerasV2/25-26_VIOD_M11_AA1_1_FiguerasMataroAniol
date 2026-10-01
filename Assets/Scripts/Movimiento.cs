using UnityEngine;
using UnityEngine.InputSystem;

public class  Movimiento : MonoBehaviour
{
    public GameObject body;
    public GameObject canon;

    public float sensibilidad = 0.25f;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float x = mouseDelta.x;
        float y = mouseDelta.y;

        body.transform.localEulerAngles += new Vector3(0, x * sensibilidad, 0);
        canon.transform.localEulerAngles += new Vector3(-y * sensibilidad, x * sensibilidad, 0);
    }
}
