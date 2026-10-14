using System.Collections.Generic;
using UnityEngine;

public class TargetsScript : MonoBehaviour
{

    public GameObject brokeTarget;
    public float destroyedTarget = 5f;
    public float timeToRespawn = 5f;
    private float timeLeft = 0f;

    public int addPoints = 100;

    private Collider col;
    private MeshRenderer meshRenderer;

    private bool isDisabled = false;

    public List<Transform> points;
    public int nextPoint = 0;
    public float speed = 5;
    public int startPoint = 0;
    public bool movingTarget = false;

    void Start()
    {

        col = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();
        
        if(points.Count > 0 && points != null)
        {
            transform.position = points[startPoint].position;
        }
        
    }

    void Update()
    {
       
        if (isDisabled)
        {
            timeLeft += Time.deltaTime;

            if (timeLeft >= timeToRespawn)
            {
                col.enabled = true;
                meshRenderer.enabled = true;
                isDisabled = false;
            }
        }
        if (movingTarget)
        {
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
    }

    private void OnTriggerEnter(Collider colision)
    {
        if (colision.gameObject.CompareTag("Bullet"))
        {
            col.enabled = false;
            meshRenderer.enabled = false;

            GameObject targetDestruido = Instantiate(brokeTarget, transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(targetDestruido, destroyedTarget);

            timeLeft = 0f;
            isDisabled = true;

            PointsEditor.instance.ernedPoints += addPoints;
        }
    }
}
