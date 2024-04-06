using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WEAPON
{

    public class HeavyWeapon : MeleeWeapon
    {

        internal override void MeleeAttack()
        {
            Debug.Log("Ataque basico con " + name);
        }

        // Se agrego este
        internal override void ChargedMeleeAttack()
        {
            base.ChargedMeleeAttack();
            Debug.Log("Ataque cargado con " + name);
        }


    }
}