using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestroyBullet : MonoBehaviour
{
    void Update()
    {
        
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Targets"))
        {
            Destroy(gameObject);
        }
    }
}
