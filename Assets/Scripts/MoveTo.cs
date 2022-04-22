using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    [SerializeField]
    private GameObject[] animals;
    private int animalIndex = 0;
    private NavMeshAgent agent;
    private SpawnAnimals animalSpawner;
    [SerializeField]
    private float gestationTime = 3;

    void Start()
    {
        animals = GameObject.FindGameObjectsWithTag("Animal");
        animalSpawner = GameObject.FindGameObjectWithTag("AnimalSpawner").GetComponent<SpawnAnimals>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (animals[animalIndex].transform.position == gameObject.transform.position)
        {
            animalIndex = animals.Length > animalIndex + 1 ? animalIndex + 1 : 0;
        }
        agent.destination = animals[animalIndex].transform.position;
        if (agent.enabled && agent.remainingDistance < 1 && agent.remainingDistance > 0.5f)
        {
            StartCoroutine(Love());
            if (animalIndex < animals.Length - 1)
            {
                animalIndex += 1;
            } else
            {
                animals = GameObject.FindGameObjectsWithTag("Animal");
                animalIndex = 0;
            }
        }
    }

    IEnumerator Love()
    {
        yield return new WaitForSeconds(gestationTime);
        animalSpawner.SpawnAnimalAtPos(gameObject, transform.position, transform.rotation);
    }
}