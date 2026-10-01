using UnityEngine;

public class Disparar : MonoBehaviour
{
    Rigidbody rb;

    public GameObject salidaBala;
    public GameObject bala;

    public float velocidadBala = 50f;
    public float tiempoBala = 5f;

    public float escalaBala = 0.25f;
    public float rotacionBala = 90f;

    private void Start()
    {
        bala.transform.localScale = new Vector3(escalaBala, escalaBala, escalaBala);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject nuevaBala = Instantiate(bala, salidaBala.transform.position, salidaBala.transform.rotation);
            nuevaBala.transform.localEulerAngles += new Vector3(0, 0, 0);
            rb = nuevaBala.GetComponent<Rigidbody>();
            rb.AddForce(salidaBala.transform.forward *  velocidadBala, ForceMode.Impulse);
            Destroy(nuevaBala, tiempoBala);
        }
    }
}
