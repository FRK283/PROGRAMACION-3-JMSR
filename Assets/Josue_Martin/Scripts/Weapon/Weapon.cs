using UnityEngine;

namespace WEAPON
{

    /// <summary>
    /// internal es public dentro de su mismo namespace
    /// 
    /// protected es publico solo para las clases que heredan
    /// no en las referencias
    /// </summary>
    public abstract class Weapon : MonoBehaviour
    {

        protected int damage;

        internal abstract void Aim(); // Este

        internal virtual void SingleShot()
        {
            Debug.Log("Single Shot");
        }

        internal virtual void AutomaticShot()
        {
            Debug.Log("Automatic Shot");
        }

        internal virtual void MeleeAttack()
        {
            Debug.Log("Melee Attack");
        }

        internal virtual void ChargedMeleeAttack() // Este
        {
            Debug.Log("Charged Melee Attack");
        }


    }
}