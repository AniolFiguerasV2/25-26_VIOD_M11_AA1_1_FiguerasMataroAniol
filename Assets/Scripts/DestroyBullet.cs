using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Targets"))
        {
            Destroy(gameObject);
        }
    }
}
