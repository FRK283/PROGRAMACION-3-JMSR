using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CambioDeArma : MonoBehaviour
{
    public GameObject[] armas; 
    private int armaActual = 0; 

    void Update()
    {
        float input = Input.GetAxis("Mouse ScrollWheel");

        if (input > 0f) 
        {
            CambiarArma(1); 
        }
        else if (input < 0f) 
        {
            CambiarArma(-1); 
        }
    }

    void CambiarArma(int cambio)
    {
        armas[armaActual].SetActive(false);

        armaActual += cambio;
        if (armaActual < 0)
        {
            armaActual = armas.Length - 1;
        }
        else if (armaActual >= armas.Length)
        {
            armaActual = 0;
        }

        armas[armaActual].SetActive(true);
    }
}


