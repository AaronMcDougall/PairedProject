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
        private Vector3 worldPosition;
        public bool isBlocked;

        public int gridX;
        public int gridY;
        public int gCost;
        public int hCost;

        public Node parent;

        public int fCost
        {
            get
            {
                return gCost + hCost;
            }
        }
    }
    
    private void Start()
    {
        //still need to attach grid to level btw
        
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
    
    //get node from world point
    public Node NodeFromWorldPos(Vector3 worldPos)
    {
        //get percentage of location across world grid
        float percentX = (worldPos.x + worldSize.x / 2) / worldSize.x;
        float percentY = (worldPos.y + worldSize.y / 2) / worldSize.y;
        //clamp between 0 and 1 
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);
        
        //getting world pos locations from percentage to int
        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);

        //sends world location to the 2D array
        return grid[x, y];
    }
    
    //void/List GetNeighbours()
    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        //checking neighbours surrounding currentNode
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                //skip currentNode
                if (x == 0 && y == 0)
                {
                    continue;

                    int checkX = node.gridX + x;
                    int checkY = node.gridY + y;
                    
                    //check neighbouring nodes are inside the array, adding to neighbours list
                    if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                    {
                        neighbours.Add(grid[checkX, checkY]);
                    }
                }
            }
        }

        return neighbours;
    }


    public List<Node> path;

    private void OnDrawGizmos()
    {
        //grid parameters outline
        Gizmos.DrawWireCube(transform.position, new Vector3(worldSize.x, worldSize.y, -1));

        /*//drawing and filling grid
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                if (grid != null && grid[x, y].isBlocked)
                {
                    Gizmos.color = Color.magenta;
                    Gizmos.DrawCube(new Vector3(x, y, 0), Vector3.one);
                }
                else
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawCube(new Vector3(x, y, 0), Vector3.one);
                }
            }
        }*/
        
        
        /*if (grid != null)
        {
            foreach (var n in grid)
            {
                Gizmos.color = (n.isBlocked) ? Color.white : Color.red;
                if (path != null)
                {
                    if (path.Contains(n))
                        Gizmos.color = Color.blue;
                    //Gizmos.DrawCube(n.worldPostion, Vector3.one);
                }
            }
        }*/
    }
}