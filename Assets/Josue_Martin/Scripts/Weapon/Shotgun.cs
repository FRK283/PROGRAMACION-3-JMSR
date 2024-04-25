using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WEAPON
{
    public class Shotgun : FireWeapon
    {
        [Header("General")]
        [SerializeField] protected TrailRenderer gunLaser;
        [SerializeField] private Transform raycastOrigin;
        private RaycastHit hit;     
        [SerializeField] private LayerMask hitMask;

        [Header("Shoot parameters")]
        [SerializeField] internal float spread;    

        [SerializeField] internal Sprite spreadRange; 

        [SerializeField] internal Transform[] birdShotOrigin;  

        [SerializeField] private float rayDistance = 100; 
        [SerializeField] private float rayForce = 500;
        
        [SerializeField] private int birdshot = 20; 
       
        [Header("Reload parameters")]
       

        private float lastTimeShoot = Mathf.NegativeInfinity;

      

        private void Awake()
        {
            damage = 1;
            fireRate = 0.02f;
            maxAmmo = 20;

            magazineAmmo = 20;
            reloadTime = 1.5f;

            birdshot = maxAmmo;
        }

        internal override void SingleShot()
        {
            if (lastTimeShoot + fireRate < Time.time) 
            {
                if (birdshot >= 1)                  
                {
                    

                    raycastOrigin = RandomShootingPoint();

                    //spread
                    float x = Random.Range(0, spread);
                    float y = Random.Range(0, spread);

                    //calculate direction with spread
                    Vector3 direction = raycastOrigin.transform.forward + new Vector3(x, y, 0);

                    Physics.Raycast(raycastOrigin.position, direction, out hit, rayDistance, hitMask);

                    TrailRenderer trail = Instantiate(gunLaser, raycastOrigin.position, Quaternion.identity);

                    StartCoroutine(SpawnTrail(trail, hit));

                    birdshot--;

                    if (hit.transform != null)
                    {
                        

                        if (hit.rigidbody != null)
                        {
                            hit.rigidbody.AddForce(-hit.normal * rayForce);
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

        private Transform RandomShootingPoint()
        {
            int randomPoint = Random.Range(0, birdShotOrigin.Length); 
            return birdShotOrigin[randomPoint];
        }

        internal override void Reload()
        {
            
            StartCoroutine(WaintingReloading());
            birdshot = birdshot + magazineAmmo;
          

            if (birdshot > 8)
            {
                birdshot = maxAmmo;
            }
           
        }

        IEnumerator WaintingReloading()
        {
            yield return new WaitForSeconds(reloadTime);
        }

        internal override void Aim()   //diferente imagen para todas las miras de todas las armas
        {

        }
    }

}


