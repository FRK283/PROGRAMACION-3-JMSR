using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WEAPON
{
    public class EnemyLifeDef : MonoBehaviour
    {
        [SerializeField] private float vida;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private GameObject arma;
        [SerializeField] private float receivedDamage = 1;
        [SerializeField] private GameObject spawner;
        [SerializeField] internal bool haMuerto = false;
        

        private void Start()
        {
            spawner = GameObject.Find("Spawner");
        }

        
        internal void TakeDamage(int receivedDamage)
        {
            
            vida -= receivedDamage;
          
            if (vida <= 0)
            {
                vida = 0; 
                haMuerto = true;   
            }

           
        }
    }

}