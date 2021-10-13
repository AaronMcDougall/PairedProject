using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WorldScanner : MonoBehaviour
{
    public LayerMask unwalkableMask;
    private Vector2 gridSize;
    public float nodeRadius;

    public Node[,] grid;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridSize.x, gridSize.y));
    }

    /*void Scan()
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int z = 0; z < size.z; z++)
            {
                if(Physics.OverlapBox(new Vector3(x * gridSize.x, 0, z * gridSize.y),
                    new Vector3(gridSize.x, gridSize.y, gridSize.z), Quaternion.identity))
                {
                    gridNodeReferences[x, z].isBlocked = true;
                }
            }
        }
    }*/
}
