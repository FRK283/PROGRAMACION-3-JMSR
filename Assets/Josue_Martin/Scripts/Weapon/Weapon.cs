using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected int Damage; // protected es cuadno solo se puede usar en su propia clase 

    internal abstract void SingleShoot()
    { 
    
    
    }

    internal abstract void AutomaticShoot()
    {


    }
    internal abstract void MeleeAttack()
    {


    }
    internal abstract void ChargedMeleeAttack()
    {


    }

}


