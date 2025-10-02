using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetScript : MonoBehaviour
{

    public GameObject targetRoto;
    public float tiempoDestruido = 5f;
    public float tiempoParaRespawn = 5f;
    private float tiempoRestante = 0f;

    private Collider col;
    private MeshRenderer meshRenderer;

    private bool estaDesactivado = false;

    void Start()
    {

        col = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();
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
    }

    private void OnTriggerEnter(Collider colision)
    {
        if (colision.gameObject.CompareTag("Balas"))
        {
            col.enabled = false;
            meshRenderer.enabled = false;

            GameObject targetDestruido = Instantiate(targetRoto, transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(targetDestruido, tiempoDestruido);

            tiempoRestante = 0f;
            estaDesactivado = true;

            Puntos.instance.puntuacion += 100;
        }
    }
}
