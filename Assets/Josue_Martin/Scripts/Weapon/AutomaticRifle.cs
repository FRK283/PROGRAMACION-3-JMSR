using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticRifle : MonoBehaviour
{
    protected TrailRenderer gunLaser;
    protected FireType fireType = FireType.automatic;
    protected int bulletPerBurst;
    internal

        internal void AutomaticShoot()
    {
        base.AutomaticShoot();
    
    
    }

    internal override void Reload()
    {
        base.Reload();


    }

    internal override void Aim()
    { 
    
    
    
    
    }



}

public enum FireType
{ 

    Automatic, burst

}
