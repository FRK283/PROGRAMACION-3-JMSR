using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target; // Referencia al objetivo a seguir (por ejemplo, el jugador)
    public NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target != null)
        {
            // Calcula la direcci�n hacia el objetivo
            Vector3 targetPosition = target.position;
            // Establece la posici�n a la que debe dirigirse el enemigo
            agent.SetDestination(targetPosition);
        }
    }
}