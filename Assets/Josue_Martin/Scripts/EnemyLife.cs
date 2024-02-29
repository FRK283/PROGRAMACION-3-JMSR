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
            Debug.Log("Entr� la bala");
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
        
        vida -= receivedDamage;
        Debug.Log(vida + " - " + receivedDamage);
      
        if (vida <= 0)
        {
          
            vida = 0;
            Debug.Log("Te va a decir que muri�");
            haMuerto = true;
            Debug.Log("Ya muri�");
        }

        Debug.Log("No se destruy� haha");
    }

}
