using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WEAPON
{

    public class HandGun : FireWeapon
    {

        protected TrailRenderer gunLaser;// Es un laser que muestra a donde apuntas

        internal override void SingleShot() // Disparo con racyast
        {
            base.SingleShot();
            Debug.Log("Disparo unico con " + name);
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
}