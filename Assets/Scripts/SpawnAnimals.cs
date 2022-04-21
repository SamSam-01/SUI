using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimals : MonoBehaviour
{
    [SerializeField]
    private GameObject[] animals;
    [SerializeField][Min(2)]
    private int maxAnimalsNbr = 50;

    [SerializeField]
    private float maxX = 100;
    [SerializeField]
    private float maxZ = 100;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < animals.Length; i++)
        {
            SpawnXAnimals(animals[i], Random.Range(2, maxAnimalsNbr));
        }
    }

    public void SpawnXAnimals(GameObject animal,  int nbrOfAnimals)
    {
        Vector3 position = Vector3.zero;
        Quaternion rotation = Quaternion.identity;

        for (int i = 0; i < nbrOfAnimals; i++)
        {
            float random_nbr = Random.Range(0, 1000);
            position.x = random_nbr % maxX;
            position.z = (random_nbr + random_nbr) % maxZ;
            rotation.y = (random_nbr + random_nbr) % 360;
            RaycastHit hit;
            if (Physics.Raycast(position, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("terrain"), QueryTriggerInteraction.UseGlobal))
            {
                Debug.Log("Spawn");
                position.y -= hit.distance + 2;
                Instantiate(animal, position, rotation);
            }
        }
    }
}
