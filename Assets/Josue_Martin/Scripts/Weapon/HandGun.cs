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
        [SerializeField] private LayerMask hitMask;

        [Header("Shoot parameters")]
        [SerializeField] private float rayDistance = 100; 
        [SerializeField] private float rayForce = 500;
        [Header("Reload parameters")]
        
        private float lastTimeShoot = Mathf.NegativeInfinity;

        private void Start()
        {
            damage = 10;
            actualAmmo = 8;
            fireRate = 0.2f;
            maxAmmo = 12;
            magazineAmmo = 13;
            reloadTime = 1.5f;

            actualAmmo = maxAmmo;
        }

        internal override void SingleShot() 
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

                            hit.transform.GetComponent<EnemyLifeDef>().TakeDamage(damage); 

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
            StartCoroutine(WaintingReloading()); 
            actualAmmo = actualAmmo + magazineAmmo;

            if (actualAmmo > maxAmmo)
            {
                actualAmmo = maxAmmo;
            }
        }

        IEnumerator WaintingReloading()
        {
            yield return new WaitForSeconds(reloadTime);
        }

        internal override void Aim() //la mira es la parte visual del raycast
        {
        }
    }

}
