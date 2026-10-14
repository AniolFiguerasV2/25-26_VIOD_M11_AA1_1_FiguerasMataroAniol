using UnityEngine;
using UnityEngine.InputSystem;

public class Shoots : MonoBehaviour
{
    Rigidbody rb;
    public InputAction shootAction;

    public GameObject bulletOutput;
    public GameObject bullet;

    public float bulletVel = 50f;
    public float BulletTime = 5f;

    public float bulletScale = 0.25f;
    public float bulletRotation = 90f;

    private void Awake()
    {
       shootAction.performed += ctx => Shoot();
    }
    private void OnEnable()
    {
        shootAction.Enable();
    }
    
    private void OnDisable()
    {
        shootAction.Disable();
    }
    private void Start()
    {
        bullet.transform.localScale = new Vector3(bulletScale, bulletScale, bulletScale);
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, bulletOutput.transform.position, bulletOutput.transform.rotation);
        newBullet.transform.localEulerAngles += new Vector3(90, 0, 0);

        rb = newBullet.GetComponent<Rigidbody>();
        rb.AddForce(bulletOutput.transform.forward * bulletVel, ForceMode.Impulse);

        Destroy(newBullet, BulletTime);
    }
}
