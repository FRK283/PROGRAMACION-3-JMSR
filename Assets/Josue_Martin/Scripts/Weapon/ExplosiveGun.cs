using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WEAPON
{

    public class ExplosiveGun : FireWeapon
    {

        protected Sprite explosionArea; // Proyectar una imagen en el hit.point del Aim, que muestra donde va a caer
        protected GameObject proyectile; // Disparo fisico, con raycast puede ser donde va a caer

        internal override void SingleShot()
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