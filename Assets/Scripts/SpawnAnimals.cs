using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimals : MonoBehaviour
{
    [SerializeField]
    private GameObject[] animals;
    [SerializeField][Min(2)]
    private int maxAnimalsNbr = 10000;
    [SerializeField]
    private int animalsSpawnNbr = 50;
    [SerializeField]
    private bool randomNbr = true;

    [SerializeField]
    private float maxX = 100;
    [SerializeField]
    private float maxZ = 100;

    private float animalsNbr = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < animals.Length; i++)
        {
            SpawnXAnimals(animals[i], randomNbr ? Random.Range(2, animalsSpawnNbr) : animalsSpawnNbr);
        }
    }

    public void SpawnXAnimals(GameObject animal, int nbrOfAnimals)
    {
        Vector3 position = Vector3.zero;
        Quaternion rotation = Quaternion.identity;

        for (int i = 0; i < nbrOfAnimals; i++)
        {
            position.x = Random.Range(0, maxX);
            position.y = 1000;
            position.z = Random.Range(0, maxZ);
            rotation.y = Random.Range(0, 360);
            RaycastHit hit;
            if (Physics.Raycast(position, Vector3.down, out hit, Mathf.Infinity) && animalsNbr < maxAnimalsNbr)
            {
                position.y -= hit.distance + 2;
                Instantiate(animal, position, rotation);
                animalsNbr++;
            }
        }
    }

    public void SpawnAnimalAtPos(GameObject animal, Vector3 position, Quaternion rotation)
    {
        RaycastHit hit;
        position.y += 100;
        if (Physics.Raycast(position, Vector3.down, out hit, Mathf.Infinity) && animalsNbr < maxAnimalsNbr)
        {
            position.y -= hit.distance + 2;
            Instantiate(animal, position, rotation);
            animalsNbr++;
        }
    }
}
