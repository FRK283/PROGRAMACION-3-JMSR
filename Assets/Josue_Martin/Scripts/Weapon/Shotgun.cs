using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WEAPON
{
    public class Shotgun : FireWeapon
    {

        protected float spread;
        protected int birdShot; // Perdigones

        protected Sprite spreadRange;

        protected Transform[] birdShotOrigin;

        /// <summary>
        /// Aqui lo que tienen que hacer, es tener minimo 9
        /// raycast, estos saldran de el arreglo de BirdShotOrigin
        /// Al disparar deben de dispersarse una distancia aleatoria de 0 a spreadRange
        /// </summary>
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