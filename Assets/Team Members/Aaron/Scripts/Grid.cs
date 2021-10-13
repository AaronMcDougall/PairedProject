using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;
using Color = UnityEngine.Color;

public class Grid : MonoBehaviour
{
    public LayerMask layer;
    
    public Vector3Int gridSize;

    public Node[,] grid;

    public class Node
    {
        public bool isBlocked;
    }

    private void Start()
    {
        grid = new Node[gridSize.x,gridSize.y];
    }

    private void Update()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                if(Physics.CheckBox(new Vector3(x * gridSize.x, y*gridSize.y, 0), new Vector3(gridSize.x, gridSize.y, gridSize.z), Quaternion.identity, layer))
                {
                    grid[gridSize.x, gridSize.y].isBlocked = true;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        //grid parameters outline
        Gizmos.DrawWireCube(transform.position, new Vector3(gridSize.x, gridSize.y, gridSize.z));

        //drawing and filling grid
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                /*if (grid[x, y].isBlocked)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawCube(new Vector3(x, y, -9), Vector3.one);
                }*/
            }
        }
    }
}
