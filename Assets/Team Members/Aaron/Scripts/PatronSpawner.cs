using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronSpawner : MonoBehaviour
{
    public GameObject patronToSpawn;
    public GameObject spawnLocation;

    public float amountToSpawn;
    
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPatrons()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            Instantiate(patronToSpawn, spawnLocation.transform.position, patronToSpawn.transform.rotation);
        }
    }
}
