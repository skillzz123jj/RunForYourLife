using UnityEngine;
using TMPro;

public class RainbowText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    public float colorChangeSpeed = 1f;

    private float hue;

    void Start()
    {
        
        hue = 0f;
    }

    void Update()
    {
        //Changes the text color
      
        hue += Time.deltaTime * colorChangeSpeed;

       
        if (hue > 1f)
            hue -= 1f;

       
        textMesh.color = Color.HSVToRGB(hue, 1f, 1f);
    }
}
