using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    private GameObject[] animals;
    private int animalIndex;
    private NavMeshAgent agent;

    void Start()
    {
        animals = GameObject.FindGameObjectsWithTag("Animal");
        agent = GetComponent<NavMeshAgent>();
        
        agent.destination = animals[animalIndex].transform.position;
    }

    private void Update()
    {
        agent.destination = animals[animalIndex].transform.position;
        if (agent.enabled && agent.remainingDistance < 0.5f)
        {
            if (animalIndex < animals.Length - 1)
            {
                animalIndex++;
            }
        }
    }
}