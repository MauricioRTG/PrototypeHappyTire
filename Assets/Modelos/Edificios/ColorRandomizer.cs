using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{
    [Tooltip("ACTIVA EL MODO DEBUG. TECLA ESPACIO PARA CAMBIAR COLOR EN REALTIME!!!")]
    public bool debug = false;

    private MeshRenderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        AplicarMaterial();
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AplicarMaterial();
        }
    }

    void AplicarMaterial ()
    {
        for (int i = 0; i < myRenderer.materials.Length; i++)
        {
            Color randColor = Random.ColorHSV(0,1 , 0.5f,0.9f , 0.4f,1);

            myRenderer.materials[i].SetColor("Color_F24BD3BC", randColor);
        }
    }
}
