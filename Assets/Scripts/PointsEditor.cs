using TMPro;
using UnityEngine;

public class PointsEditor : MonoBehaviour
{
    public float ernedPoints = 0f;
    public TextMeshProUGUI textMeshPro;
    public static PointsEditor instance;
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
            textMeshPro.text = ernedPoints.ToString();
        }
    }
}
