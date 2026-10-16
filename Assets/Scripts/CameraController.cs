using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform camera;
    public InputActionReference movement;

    public float sensibilityVertical = 3.0f;
    public float sensibilityHorizontal = 3.0f;

    public float cameraDistance = 5.0f;

    public LayerMask floor;
    public float marginCollision = 0.2f;

    public float Xrot;
    public float Yrot;

    public void OnEnable()
    {
        movement.action.Enable();
    }

    public void OnDisable()
    {
        movement.action.Disable();
    }

    public void LateUpdate()
    {
        Vector2 input = movement.action.ReadValue<Vector2>();

        Yrot += input.x * sensibilityHorizontal;
        Xrot -= input.y * sensibilityVertical;

        Xrot = Mathf.Clamp(Xrot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(-Xrot, Yrot, 0f);

        Vector3 dir = -transform.forward;
        
        float finalDistance = cameraDistance;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, dir, out hit, cameraDistance, floor, QueryTriggerInteraction.Ignore))
        {
            finalDistance = hit.distance - marginCollision;
            if(finalDistance < 0f)
            {
                finalDistance = 0f;
            }
        }

        camera.position = transform.position + dir * finalDistance;

        camera.LookAt(transform.position);
    }
}
