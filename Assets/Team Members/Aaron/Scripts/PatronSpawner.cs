using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;
using Random = UnityEngine.Random;

public class PatronSpawner : MonoBehaviour
{
    public GameObject patronToSpawn;
    public CrowdManagerScript cm;
    public List<GameObject> PatronList = new List<GameObject>();

    private int spawndelay;

    public float spawnXMin;
    public float spawnXMax;

    public float spawnZMin;
    public float spawnZMax;

    public float amountToSpawn;

    private void Start()
    {
        spawndelay = Random.Range(3, 6);
        cm = GetComponent<CrowdManagerScript>();
    }

    private void Update()
    {
        
    }

    //spawn a bunch of patrons at once
    public void SpawnPatrons()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            GameObject copy = Instantiate(patronToSpawn, new Vector3(Random.Range(spawnXMin, spawnXMax), 1.65f,
                Random.Range(spawnZMin, spawnZMax)), patronToSpawn.transform.rotation);
            //local list for clearing
            PatronList.Add(copy);
            //adding to crowd control list
            AddToCrowdList(copy);
        }
    }

    //spawn a few at a time as space clears
    public void TrickleSpawn(int amount)
    {
        Debug.Log("Test Trickle");

        for (int i = 0; i <= amount; i++)
        {
            GameObject copy = Instantiate(patronToSpawn, new Vector3(Random.Range(spawnXMin, spawnXMax), 1.65f,
                Random.Range(spawnZMin, spawnZMax)), patronToSpawn.transform.rotation);
            //local list for clearing
            PatronList.Add(copy);
            //adding to crowd control list
            AddToCrowdList(copy);
            //keeps topping up to capacity per spawn
            cm.capacity += 1;
        }
    }

    //crowd list for crowd manager
    void AddToCrowdList(GameObject dude)
    {
        cm.PatronList.Add(dude);
    }

    //deletes any spawned patrons
    public void ClearPatrons()
    {
        foreach (var patron in PatronList)
        {
            DestroyImmediate(patron, true);
        }
        PatronList.Clear();
        cm.PatronList.Clear();
    }
}