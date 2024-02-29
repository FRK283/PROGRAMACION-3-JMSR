using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float receivedDamage = 1;
    [SerializeField] internal bool haMuerto = false;
 

    private void Start()
    {
   
    }

    private void OnTriggerEnter(Collider bullet)
    {

        if (bullet.CompareTag("Balas"))
        {
            Debug.Log("Entró la bala");
            receivedDamage = bullet.GetComponentInParent<Nerf>().weaponDamage;
            Debug.Log("Received damage = " + receivedDamage);

            Debug.Log("El danio es igual a " + receivedDamage);
            TakeDamage();
        }
        
        else
        {
            Debug.Log("Nada");
        }
    }
    private void TakeDamage()
    {
        //AudioManager.Instance.PlayMusic("Hit");
        vida -= receivedDamage;
        Debug.Log(vida + " - " + receivedDamage);
        //rend.material = danioMaterial;
        //lastimao = true;
        //StartCoroutine(daniTime());

        if (vida <= 0)
        {
            //Destroy(this.gameObject);
            vida = 0;
            Debug.Log("Te va a decir que murió");
            haMuerto = true;
            //spawner.GetComponent<Spawner>().EnemigoMuerto(true);
            Debug.Log("Ya murió");
        }

        Debug.Log("No se destruyó haha");
    }

}
