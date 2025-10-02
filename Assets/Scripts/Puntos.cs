using TMPro;
using UnityEngine;

public class Puntos : MonoBehaviour
{
    public float puntuacion = 0f;
    public TextMeshProUGUI textMeshPro;
    public static Puntos instance;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = puntuacion.ToString();
        }
    }
}
