using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawn : MonoBehaviour
{
    public GameObject thingToSpawn;

    public int numberToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            Instantiate(thingToSpawn, new Vector3(Random.Range(-50,20), 2, Random.Range(-60,-10)), Quaternion.Euler(0, Random.Range(0, 359), 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
