using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;
using Color = UnityEngine.Color;

public class ScanningGrid : MonoBehaviour
{
    public LayerMask layer;
    public Vector2Int worldSize;

    private Node[,] grid;

    private int gridSizeX;
    private int gridSizeY;
    private int nodeSize = 1;

    public class Node
    {
        public bool isBlocked;
    }
    
    private void Start()
    {
        //how many grid spots in the world
        gridSizeX = Mathf.RoundToInt(worldSize.x / nodeSize);
        gridSizeY = Mathf.RoundToInt(worldSize.y / nodeSize);
        
        grid = new Node [worldSize.x, worldSize.y] ;
        CreateGrid();
    }

    void CreateGrid()
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                grid[x, y] = new Node();
                if ((Physics.CheckBox(new Vector3(x, y, 0),
                    new Vector2(nodeSize, nodeSize), Quaternion.identity, layer)))
                {
                    grid[x, y].isBlocked = true;
                }
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        //grid parameters outline
        Gizmos.DrawWireCube(transform.position, new Vector3(worldSize.x, worldSize.y, -1));

        //drawing and filling grid
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                if (grid != null && grid[x, y].isBlocked)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawCube(new Vector3(x, y, 0), Vector3.one);
                }
                else
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawCube(new Vector3(x, y, 0), Vector3.one);
                }
            }
        }
    }
}