using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FueraDeRango : MonoBehaviour
{
    [SerializeField] internal bool fueraDeRango = false;
   

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")) 
        {
            fueraDeRango = true;
        }
    }

}
