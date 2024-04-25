using UnityEngine;

namespace WEAPON
{

 
   
    public abstract class Weapon : MonoBehaviour
    {

        protected int damage;

        internal abstract void Aim(); 

        internal virtual void SingleShot()
        {
        }

        internal virtual void AutomaticShot()
        {
        }

        internal virtual void MeleeAttack()
        {
        }

        internal virtual void ChargedMeleeAttack()
        {
        }


    }
}