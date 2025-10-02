using UnityEngine;

public class Disparar : MonoBehaviour
{

    Rigidbody rb;

    public GameObject salidaBala;
    public GameObject bala;

    public float velocidadBala = 50f;
    public float tiempoBala = 5f;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject nuevaBala = Instantiate(bala, salidaBala.transform.position, salidaBala.transform.rotation);
            rb = nuevaBala.GetComponent<Rigidbody>();
            rb.AddForce(salidaBala.transform.forward *  velocidadBala, ForceMode.Impulse);
            Destroy(nuevaBala, tiempoBala);
        }

    }
}
