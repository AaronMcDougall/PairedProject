using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class Pathfinding : MonoBehaviour
{
    private ScanningGrid.Node node;

    public Transform beginning, finish;

    private Vector3 beginningPos;

    //ref to Grid
    public List<ScanningGrid.Node> openSet = new List<ScanningGrid.Node>();
    public List<ScanningGrid.Node> closedSet = new List<ScanningGrid.Node>();
    
    private ScanningGrid grid;

    private void Start()
    {
        node = GetComponent<ScanningGrid.Node>();
        grid = GetComponent<ScanningGrid>();
        FindPath(beginning.position, finish.position);
    }

    private void Update()
    {
        beginningPos = beginning.transform.position;
    }

    //get start and finish points in Node Space
    void FindPath(Vector3 startPos, Vector3 endPos)
    {
        ScanningGrid.Node startNode = grid.NodeFromWorldPos(startPos);
        ScanningGrid.Node endNode = grid.NodeFromWorldPos(endPos);
        
        //why are the lists in here (local) and not set as normal?


        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            //creates node for current space; assigns to list
            ScanningGrid.Node currentNode = openSet[0];

            /*for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {

                    
                    if (x == 0 && y == 0)
                    {
                        continue;
                    }
                    else
                    {
                        var checkX = node.gridX + x;
                        var checkY = node.gridY + y;
                        openSet.Add(grid[checkX, checkY]);
                    }
                }
            }*/

            //starts the loop at the neighbours
            for (int i = 1; i < openSet.Count; i++)
            {
                //if the fCost value is lower than the current node being checked OR if the same, finding closest to endNode
                if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                {
                    //set the smaller value node as currentNode 
                    currentNode = openSet[i];
                }

                Debug.Log("OpenSet = " + openSet.Count);
            }
            
            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            //if we've reached the endNode, end the loop
            if (currentNode == endNode)
            {
                RetracePath(startNode, endNode);
                return;
            }
            
            //check the neighbours in list for traversable/already visited
            foreach (var neighbour in grid.GetNeighbours(currentNode))
            {
                //if so, skip it
                if (neighbour.isBlocked = true || closedSet.Contains(currentNode))
                {
                    continue;
                }
                else
                {
                    //checking if neighbour is shorter than previous path or not in openSet
                    int newCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                    if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                    {
                        //set gCost; hCost of neighbour
                        neighbour.gCost = newCostToNeighbour;
                        neighbour.hCost = GetDistance(neighbour, endNode);
                        //makes neighbour a parent (Node)
                        neighbour.parent = currentNode;

                        //if neighbour is not in openSet, add it to there
                        if (!openSet.Contains(neighbour))
                        {
                            openSet.Add(neighbour);
                        }
                    }
                }
                
            }
           
        }
    }

    void RetracePath(ScanningGrid.Node startNode, ScanningGrid.Node endNode)
    {
        //creates a list for successful path nodes
        List<ScanningGrid.Node> path = new List<ScanningGrid.Node>();
        //starting at the end and working back
        ScanningGrid.Node currentNode = endNode;
        //loop until reaches the start
        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        //reverse from tracing backwards
        path.Reverse();

        grid.path = path;
    }

    int GetDistance(ScanningGrid.Node nodeStart, ScanningGrid.Node nodeEnd)
    {
        //gets the distance between start and end nodes on x and y axis
        int distanceX = Mathf.Abs(nodeStart.gridX - nodeEnd.gridX);
        int distanceY = Mathf.Abs(nodeStart.gridY - nodeEnd.gridY);

        //14* for diagonal movement, 10* for direct/straight movement
        if (distanceX > distanceY)
        
            return 14 * distanceY + 10 * (distanceX = distanceY);
        //else if (distanceY > distanceX)
        return 14 * distanceX + 10 * (distanceY - distanceX);
    }
    
}
