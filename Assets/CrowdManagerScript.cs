using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdManagerScript : MonoBehaviour
{
    
    public List<GameObject> patronList = new List<GameObject>();

    public PatronSetup ps;

    public float crowdAggression;
    public float patronAggression;
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (var patron in patronList)
        {
            patronAggression = ps.aggression;
            Debug.Log("patron " + patronAggression);
        }

        crowdAggression = patronAggression / patronList.Count;
    }
}