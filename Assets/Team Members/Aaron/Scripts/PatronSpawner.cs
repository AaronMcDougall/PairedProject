using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PatronSpawner : MonoBehaviour
{
    public GameObject patronToSpawn;
    public GameObject cm;
    public List<GameObject> PatronList = new List<GameObject>();

    public float spawnXMin;
    public float spawnXMax;

    public float spawnZMin;
    public float spawnZMax;

    public float amountToSpawn;

    public void SpawnPatrons()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            GameObject copy = Instantiate(patronToSpawn, new Vector3(Random.Range(spawnXMin,spawnXMax), 1.65f, 
                Random.Range(spawnZMin, spawnZMax)), patronToSpawn.transform.rotation);
            //local list for clearing
            PatronList.Add(copy);
            //adding to crowd control list
            AddToCrowdList(copy);
        }
    }

    public void TrickleSpawn(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject copy = Instantiate(patronToSpawn, new Vector3(Random.Range(spawnXMin, spawnXMax), 1.65f,
                Random.Range(spawnZMin, spawnZMax)), patronToSpawn.transform.rotation);
            //local list for clearing
            PatronList.Add(copy);
            //adding to crowd control list
            AddToCrowdList(copy);
        }
    }

    void AddToCrowdList(GameObject dude)
    {
        //cms.patronList.Add(copy);
        cm.GetComponent<CrowdManagerScript>().patronList.Add(dude);
    }

    public void ClearPatrons()
    {
        foreach (var patron in PatronList)
        {
            DestroyImmediate(patron, true);   
        }
        PatronList.Clear();
    }
}
