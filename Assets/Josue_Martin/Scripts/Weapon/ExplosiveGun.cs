using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WEAPON
{

    public class ExplosiveGun : FireWeapon
    {

        [Header("General")]
        [SerializeField] protected TrailRenderer gunLaser;
        [SerializeField] private Transform raycastOrigin;
        private RaycastHit hit;
        [SerializeField] private LayerMask hitMask;
        public GameObject impactParticlesPrefab;

        public GameObject bulletPrefab; // Prefab de la bala
        public Transform firePoint; // Punto desde el cual se lanzará la bala
        public float bulletSpeed = 10f; // Velocidad de la bala


        [Header("Shoot parameters")]
        [SerializeField] private float rayDistance = 100; //fire range, hasta dónde llega
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

        internal override void SingleShot() //disparo con raycast
        {



            if (lastTimeShoot + fireRate < Time.time) //este te dice si puedes disparar porque ya pasó el tiempo del last time shot
            {
                if (actualAmmo >= 1)                    //este te dice si tienes balas
                {
                    Debug.Log("Disparo básico con " + name);
                    Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, rayDistance, hitMask);

                    TrailRenderer trail = Instantiate(gunLaser, raycastOrigin.position, Quaternion.identity);

                    // Instanciar la bala en el punto de fuego
                    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

                    // Obtener el Rigidbody de la bala
                    Rigidbody rb = bullet.GetComponent<Rigidbody>();

                    // Aplicar velocidad a la bala
                    rb.velocity = firePoint.forward * bulletSpeed;

                    // Destruir la bala después de un tiempo si no golpea nada
                    Destroy(bullet, 2f);

                    StartCoroutine(SpawnTrail(trail, hit));

                    actualAmmo--;

                    if (hit.transform != null)
                    {
                        if (hit.transform)
                        {
                            Instantiate(impactParticlesPrefab, hit.point, Quaternion.identity);

                            Debug.Log("Disparaste a " + hit.transform.name);
                        }

                        if (hit.rigidbody != null)
                        {
                            hit.rigidbody.AddForce(-hit.normal * rayForce);
                        }

                        if (hit.transform.CompareTag("Enemy"))
                        {
                            // hit.collider.gameObject.SetActive(false);

                            Instantiate(impactParticlesPrefab, hit.point, Quaternion.identity);

                            hit.transform.GetComponent<EnemyLifeDef>().TakeDamage(damage); //aquí estamos mandando al TakeDamage el damage, que es lo que está dentro de los paréntesis
                            Debug.Log("Golpeaste a un enemigo");

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
            Debug.Log("Recargando " + name);
            StartCoroutine(WaintingReloading());
            Debug.Log("Recargando " + name + " " + actualAmmo + " " + magazineAmmo);
            actualAmmo = actualAmmo + magazineAmmo;
            Debug.Log(name + " " + actualAmmo);

            if (actualAmmo > maxAmmo)
            {
                actualAmmo = maxAmmo;
            }
            Debug.Log(actualAmmo);
            //terminar animación de recarga
        }

        IEnumerator WaintingReloading()
        {
            yield return new WaitForSeconds(reloadTime);
            Debug.Log("Recargada " + name);
        }

        internal override void Aim() //la mira es la parte visual del raycast
        {
            Debug.Log("Apuntando con " + name);
        }
    }
}