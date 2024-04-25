using System;
using UnityEngine;

namespace WEAPON
{
    /// <summary>
    /// Se manejaran el uso, cambio y adquisicion de arma
    /// </summary>
    public class WeaponHandler : MonoBehaviour
    {

        /// <summary>
        /// CREAR EN EL INPUT EN EL INPUT HANDLER, UNA FORMA DE REALIZAR EL 
        /// CAMBIO DE ARMA
        /// 
        /// Y CAMBIAR ARMA
        /// CON LA RUEDA DEL MOUSE
        /// </summary>

        [SerializeField] private Weapon[] weapons = new Weapon[2];
        [SerializeField] private Weapon currentWeapon;
        [SerializeField] private int currentWeaponIndex;

        private Action? WeaponInputs;

        private Action? UseWeapon;
        private Action? UseAndHoldWeapon;
        private Action? WeaponAim;
        private Action? Reload;

        public GameObject[] armas; // Arreglo de GameObjects que representan tus armas
        private int armaActual = 0;

        #region Core

        private void Start()
        {
            currentWeapon = weapons[0];
            currentWeaponIndex = 0;
            SwitchFunction();
        }

        private void Update()
        {
            WeaponInputs();
            SwitchWeapon();  
        }

        #endregion

       

        private void SwitchWeapon()
        {
            
            if (InputHandler.Scroll() > 0) // 1 Significa que scrollee hacia arriba
            {
                CambiarArma(1);
                currentWeaponIndex++;
                currentWeaponIndex = currentWeaponIndex >= weapons.Length ? 0 : currentWeaponIndex; 
                currentWeapon = weapons[currentWeaponIndex];   
                SwitchFunction();
            }
            else if(InputHandler.Scroll() < 0)  // -1 Significa que scrollee hacia abajo
            {
                CambiarArma(-1); // Cambiar al arma anterior

                currentWeaponIndex--;
                currentWeaponIndex = currentWeaponIndex < 0 ?  weapons.Length-1 : currentWeaponIndex;
                currentWeapon = weapons[currentWeaponIndex];
                SwitchFunction();
            }

           

        }

        void CambiarArma(int cambio)
        {
            // Desactivar el GameObject del arma actual
            armas[armaActual].SetActive(false);

            // Calcular el nuevo índice del arma
            armaActual += cambio;
            if (armaActual < 0)
            {
                armaActual = armas.Length - 1;
            }
            else if (armaActual >= armas.Length)
            {
                armaActual = 0;
            }

            // Activar el GameObject del nuevo arma
            armas[armaActual].SetActive(true);
        }

        private void SwitchFunction()
        {
            switch (currentWeapon)
            {
                case HeavyWeapon:
                    {
                        UseWeapon = currentWeapon.MeleeAttack;
                        UseAndHoldWeapon = currentWeapon.ChargedMeleeAttack;
                        WeaponAim = currentWeapon.Aim;
                        Reload = null;
                        WeaponInputs = HeavyMeleeInput;
                        break;
                    }

                case PesoPluma:
                    {
                        UseWeapon = currentWeapon.MeleeAttack;
                        WeaponAim = currentWeapon.Aim;
                        UseAndHoldWeapon = null;
                        Reload = null;
                        WeaponInputs = LightMeleeInput;
                        break;
                    }

                case AutomaticRfile automaticRifle:
                    {
                        UseWeapon = null;
                        UseAndHoldWeapon = automaticRifle.AutomaticShot;
                        WeaponAim = automaticRifle.Aim;
                        Reload = automaticRifle.Reload;
                        WeaponInputs = AutomaticInput;
                        break;
                    }

                case HandGun handGun:
                    {
                        UseWeapon = handGun.SingleShot;
                        UseAndHoldWeapon = null;
                        WeaponAim = handGun.Aim;
                        Reload = handGun.Reload;
                        WeaponInputs = SemiAutomaticInput;
                        break;
                    }

                case Shotgun shotgun:
                    {
                        UseWeapon = shotgun.SingleShot;
                        UseAndHoldWeapon = null;
                        WeaponAim = shotgun.Aim;
                        Reload = shotgun.Reload;
                        WeaponInputs = SemiAutomaticInput;
                        break;
                    }

                case ExplosiveGun explosionGun:
                    {
                        UseWeapon = explosionGun.SingleShot;
                        UseAndHoldWeapon = null;
                        WeaponAim = explosionGun.Aim;
                        Reload = explosionGun.Reload;
                        WeaponInputs = SemiAutomaticInput;
                        break;
                    }


            }
        }

        #region Weapons Configs

        private void AutomaticInput()
        {
            if (InputHandler.ShootKey())
            {
                UseAndHoldWeapon();
            }

            if (InputHandler.AimInput())
            {
                WeaponAim();
            }

            if (InputHandler.Reload())
            {
                Reload();
            }
        }

        private void SemiAutomaticInput()
        {
            if (InputHandler.ShootKey())
            {
                UseWeapon();
            }

            if (InputHandler.AimInput())
            {
                WeaponAim();
            }

            if (InputHandler.Reload())
            {
                Reload();
            }
        }

        private void LightMeleeInput()
        {
            if ( InputHandler.ShootKey())
            {
                UseWeapon();
            }
      
            if (InputHandler.AimInput())
            {
                WeaponAim();
            }     
        }
        
        private void HeavyMeleeInput()
        {
            if (InputHandler.ShootKey())
            {
                UseWeapon();
            }

            if (InputHandler.ShootKey())
            {
                UseAndHoldWeapon();
            }

            if (InputHandler.AimInput())
            {
                WeaponAim();
            }
        }

        #endregion



    }
}
