using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WEAPON
{
    public class AutomaticRfile : FireWeapon
    {
        
    
       

        [Header("Fire Type")]
        [SerializeField] internal FireType fireType = FireType.Automatic; 
        [SerializeField] internal int bulletPerBurst; 

        [Header("General")]
        [SerializeField] internal TrailRenderer gunLaser; 
        [SerializeField] internal Transform laserOrigin;

        [SerializeField] internal Transform raycastOrigin;
        private RaycastHit hit;
        [SerializeField] internal GameObject bulletPrefabSprite;
        [SerializeField] internal LayerMask hitMask;


        [Header("Shoot parameters")]
        [SerializeField] internal float rayDistance = 100; 
        [SerializeField] internal float rayForce = 500;
        

        [Header("Reload parameters")]
        

        private float lastTimeShoot = Mathf.NegativeInfinity;


        private void Awake()
        {
            damage = 10;
            actualAmmo = 25;
            fireRate = 0.1f;
            maxAmmo = 30;
            magazineAmmo = 30;
            reloadTime = 1.5f;

            actualAmmo = maxAmmo;

            
        }

        internal override void AutomaticShot()
        {
            if (lastTimeShoot + fireRate < Time.time) 
            {
                if (actualAmmo >= 1)                    
                {
                  
                    Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, rayDistance, hitMask);

                    TrailRenderer trail = Instantiate(gunLaser, raycastOrigin.position, Quaternion.identity);

                    StartCoroutine(SpawnTrail(trail, hit));

                    actualAmmo--;

                    if (hit.transform != null)
                    {
                      
                        if (hit.rigidbody != null)
                        {
                            hit.rigidbody.AddForce(-hit.normal * rayForce);
                        }

                        if (hit.transform.CompareTag("Enemy"))
                        {

                            hit.transform.GetComponent<EnemyLifeDef>().TakeDamage(damage); //aquí estamos mandando al TakeDamage el damage, que es lo que está dentro de los paréntesis
                           

                        }

                        lastTimeShoot = Time.time;
                    }
                }
            }
        }

        private IEnumerator SpawnTrail(TrailRenderer trail, RaycastHit hit)
        {
            float time = 0;
            Vector3 startPosition = trail.transform.position;

            while (time < 1)
            {
                trail.transform.position = Vector3.Lerp(startPosition, hit.point, time);
                time += Time.deltaTime / trail.time;

                yield return null;
            }

            trail.transform.position = hit.point;

            Destroy(trail.gameObject, trail.time);
        }

        internal override void Reload()
        {
            //comenzar animación de recarga
          
            StartCoroutine(WaintingReloading());
            Debug.Log("Recargando " + name + " " + actualAmmo + " " + magazineAmmo);
            actualAmmo = actualAmmo + magazineAmmo;
           

            if (actualAmmo > 8)
            {
                actualAmmo = maxAmmo;
            }
            
        }

        IEnumerator WaintingReloading()
        {
            yield return new WaitForSeconds(reloadTime);
          
        }

        internal override void Aim()
        {
        }
    }

    [SerializeField]
    internal enum FireType
    {
        Automatic, Burst
    }

}