using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WEAPON
{

    public class AutomaticRfile : FireWeapon
    {

        /// <summary>
        /// TAREA/EJERCICIO
        /// 
        /// Crear un script para que en el
        /// inspector dependiendo de si esta puesto
        /// el modo Burst, se vea o no la
        /// variable bulletsPerBurst
        /// </summary>

        
        internal TrailRenderer gunLaser; // Es un laser que muestra a donde apuntas
        internal FireType fireType = FireType.Automatic; // Esto no lo hagan, esto lo hacemos regresando
        internal int bulletsPerBurst; // Esto no lo hagan, esto lo hacemos regresando

        internal override void AutomaticShot() // Disparo con racyast
        {
            base.AutomaticShot();
            Debug.Log("Disparo automatico con " + name);
        }

        internal override void Reload()
        {
            base.Reload();
            Debug.Log("Recargando " + name);
        }

        internal override void Aim()
        {
            Debug.Log("Apuntando con " + name);
        }
    }

    internal enum FireType
    {
        Automatic, Burst
    }
}