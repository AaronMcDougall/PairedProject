using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;
using Color = UnityEngine.Color;

public class ScanningGrid : MonoBehaviour
{
    public LayerMask layer;
    public Vector2 worldSize;

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
        gridSizeX = Mathf.RoundToInt(worldSize.x / nodeSize);
        gridSizeY = Mathf.RoundToInt(worldSize.y / nodeSize);
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        
        for (int x = 0; x < gridSizeX; x++)
        {

            for (int y = 0; y < gridSizeY; y++)
            {

                bool isBlocked = !(Physics.CheckBox(new Vector3(x, y, 0), 
                    new Vector2(nodeSize, nodeSize), Quaternion.identity, layer));
                
                grid[x, y] = new Node();
                
                Debug.Log(grid);

            }
        }
    }
    private void OnDrawGizmos()
    {
        //grid parameters outline
        Gizmos.DrawWireCube(transform.position, new Vector3(worldSize.x, worldSize.y, -1));

        //drawing and filling grid
        for (int x = 0; x < worldSize.x; x++)
        {
            for (int y = 0; y < worldSize.y; y++) {

                    Gizmos.DrawCube(new Vector3(x, y, -1), Vector3.one);
            }
        }
    }
}