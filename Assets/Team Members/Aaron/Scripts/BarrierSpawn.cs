using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BarrierSpawn : MonoBehaviour
{
    public GameObject barrier;
    private GameObject copy;

    private int entranceLocation;
    private int barrierDivision;
    public int barrierLength;
    public int entranceNumber;
    
    public float x;
    public float spawnStart;

    // Start is called before the first frame update
    void Start()
    {
        spawnStart = transform.position.x;
        SpawnBarrier();
        barrierDivision = entranceNumber + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBarrier()
    {
        for (x = spawnStart; x < barrierLength; x++)
        {
            copy = Instantiate(barrier, new Vector3(x, transform.position.y, transform.position.z),
                barrier.transform.rotation);
        }

        /*if (x == barrierLength / barrierDivision)
        {
            Destroy(copy);
        }*/
    }
}