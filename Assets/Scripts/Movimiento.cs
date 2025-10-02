using UnityEngine;
using UnityEngine.InputSystem;

public class  Movimiento : MonoBehaviour
{
    public GameObject cuerpo;
    public GameObject canon;

    
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        cuerpo.transform.localEulerAngles += new Vector3(0, x, 0);
        canon.transform.localEulerAngles += new Vector3(y, x, 0);
    }
}
