using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WEAPON
{

    public class HeavyWeapon : MeleeWeapon
    {

        // Etiqueta para identificar los enemigos
        public string etiquetaEnemigo = "Enemy";

        private void OnCollisionEnter(Collision collision)
        {
            // Verificar si la colisión es con un objeto que tiene la etiqueta de enemigo
            if (collision.gameObject.CompareTag(etiquetaEnemigo))
            {
                // Desactivar el GameObject del enemigo
                collision.gameObject.SetActive(false);
            }
        }
    }

}
