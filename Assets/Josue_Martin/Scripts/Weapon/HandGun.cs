using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace WEAPON
{

    public class HandGun : FireWeapon
    {
        [Header("General")]
        [SerializeField] protected TrailRenderer gunLaser;
        [SerializeField] private Transform raycastOrigin;
        private RaycastHit hit;
        [SerializeField] private GameObject bulletPrefabSprite;
        [SerializeField] private  LayerMask hitMask;
        
        [Header("Shoot parametera")]
        [SerializeField] private float rayDistance = 100;
        [SerializeField] private float rayForce = 500;

        private float lastTimeShoot = Mathf.NegativeInfinity;

        private void Awake() 
        {
            damage = 1;
            actualAmmo = 5;
            fireRate = 0.5f;
            maxAmmo = 8;
            magazineAmmo = 8;
            reloadTime = 1.5f;

            actualAmmo = maxAmmo;


        }


        internal override void SingleShot() // Disparo con racyast
        {
            if (lastTimeShoot + fireRate < Time.time)
            {
                if (actualAmmo >= 1)
                {
                    Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, rayDistance, hitMask);

                    TrailRenderer trail = Instantiate(gunLaser, raycastOrigin.position, Quaternion.identity);

                    StartCoroutine(SpawnTrail(trail, hit));

                    actualAmmo--;

                }
            }
        }

        private IEnumerator  SpawnTrail (TrailRenderer trail,  RaycastHit hit ) 
        {
            float time = 0; 
            Vector3 starPosition = trail.transform.position;

            while (time < 1)
            {
                trail.transform.position = Vector3.Lerp(starPosition, hit.point, time);
                time += Time.deltaTime / trail.time; 
                yield return null;


            }

            trail.transform.position = hit.point ;

            Destroy(trail.gameObject, trail.time);
            

        }




        internal override void Reload() 
        {
            StartCoroutine(WaitingReloading());
            actualAmmo = actualAmmo + magazineAmmo;

            if (actualAmmo > 8)
            {
                actualAmmo = maxAmmo;

            }

        }

        IEnumerator WaitingReloading()
        {
            yield return new WaitForSeconds(reloadTime);

        
        }

    }


}