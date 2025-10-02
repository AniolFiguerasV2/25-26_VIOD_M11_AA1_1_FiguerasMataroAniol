using System.Collections.Generic;
using UnityEngine;

public class TargetsMovement : MonoBehaviour
{
   

    public GameObject targetRoto;
    public float tiempoDestruido = 5f;
    public float tiempoParaRespawn = 5f;
    private float tiempoRestante = 0f;

    private Collider col;
    private MeshRenderer meshRenderer;

    private bool estaDesactivado = false;

    public List<Transform> points;
    public int nextPoint = 0;
    public float speed = 5;
    public int startPoint = 0;

    void Start()
    {
        col = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();

        transform.position = points[startPoint].position;
    }

    void Update()
    {
        if (estaDesactivado)
        {
            tiempoRestante += Time.deltaTime;

            if (tiempoRestante >= tiempoParaRespawn)
            {
                col.enabled = true;
                meshRenderer.enabled = true;
                estaDesactivado = false;
            }
        }
        Vector3 dir = points[nextPoint].position - transform.position;
        float distance = dir.magnitude;
        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;

        if (distance < 0.1f)
        {
            nextPoint++;
            if (nextPoint >= points.Count)
            {
                nextPoint = 0;
            }
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Balas"))
        {
            col.enabled = false;
            meshRenderer.enabled = false;

            GameObject targetDestruido = Instantiate(targetRoto, transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(targetDestruido, tiempoDestruido);

            tiempoRestante = 0f;
            estaDesactivado = true;

            Puntos.instance.puntuacion += 500;
        }
        
    }
    
}
