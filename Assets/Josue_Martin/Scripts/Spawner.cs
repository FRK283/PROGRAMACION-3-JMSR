using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace WEAPON
{
    public class Spawner : MonoBehaviour
    {
        [Header("Variables")]

        [Tooltip("Aquí se van a poner los emptys con de spawnpoint")]
        [SerializeField] private Transform[] spawnPoints;

        [SerializeField] private GameObject enemy;

        [SerializeField, Tooltip("Cantidad de enemigos en la ronda")]
        private int amountofEnemies;

        [SerializeField, Tooltip("Cantidad de enemigos que tendremos a disposición")]
        private int totalAmountofEnemies;

        [SerializeField] private float spawnRate;

        [SerializeField] private Queue<GameObject> enemyPool;

        [SerializeField] Transform poolParent;

        [SerializeField] bool haMuerto = true;


        private void Start()
        {

            PoolStart();
        }

        private void Update()
        {
        }

        private void PoolStart()
        {
            enemyPool = new Queue<GameObject>();
            for (int i = 0; i < totalAmountofEnemies; i++)
            {
                GameObject enemy = Instantiate(this.enemy);
                enemy.name = "Enemy" + i;
                enemy.transform.parent = poolParent;
                enemyPool.Enqueue(enemy);
                enemy.SetActive(false);
            }

            StartCoroutine(SpawnEnemiesQueue());
        }

        private IEnumerator SpawnEnemiesQueue()
        {
            for (int i = 0; i < amountofEnemies; i++)
            {
                StartCoroutine(CallEnemy(CalledEnemy()));
                yield return new WaitForSeconds(spawnRate);
            }
        }

        private IEnumerator CallEnemy(GameObject enemy)
        {
            yield return new WaitUntil(() => enemy.GetComponent<EnemyLifeDef>().haMuerto );


            Debug.Log("Va a murió el mono " + enemy.name);
            enemyPool.Enqueue(enemy);
            enemy.GetComponent<EnemyLifeDef>().haMuerto = false;
            enemy.SetActive(false);
            Debug.Log("Esto nos dice si sí se pudo apagar el mono");
            yield return new WaitForSeconds(1);


        }

        private GameObject CalledEnemy()
        {
            GameObject enemyToSpawn = enemyPool.Dequeue();
            enemyToSpawn.SetActive(true);
            enemyToSpawn.transform.position = RandomSpawn().position;
            return enemyToSpawn;
        }


        private Transform RandomSpawn()
        {
            int randomSpawn = Random.Range(0, spawnPoints.Length);
            return spawnPoints[randomSpawn];
        }

    }
}
