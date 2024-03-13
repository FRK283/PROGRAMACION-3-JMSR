using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    private Weapon[] weapons = new Weapon[2];
    private Weapon curretnWeapon;

    private Action UseWeapon;
    private Action UseAndHoldWeapon;


    private void Start()
    {
        curretnWeapon = weapons[0];

        if (curretnWeapon is  HeavyWeapon ) 
        {
            UseWeapon = curretnWeapon.MeleeAttack;
            UseAndHoldWeapon = curretnWeapon.ChargedMeleeAttack;
            WeaponAim = curretnWeapon.Aim;

        }

        switch (curretnWeapon)
        { 

        
        
        
        
        }
 
        
    }


    private void Update()
    {

    }


}
