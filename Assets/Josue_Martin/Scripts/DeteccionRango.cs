using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionRango : MonoBehaviour
{

    [SerializeField] internal bool jugadorRango = false;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorRango = true;
        }
    }
}
