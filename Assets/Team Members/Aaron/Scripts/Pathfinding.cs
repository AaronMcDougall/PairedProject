using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class Pathfinding : MonoBehaviour
{

    public Transform beginning, finish;
    //ref to Grid
    private ScanningGrid grid;

    private void Start()
    {
        grid = GetComponent<ScanningGrid>();
    }

    private void Update()
    {
        FindPath(beginning.position, finish.position);
    }

    //get start and finish points in Node Space
    void FindPath(Vector3 startPos, Vector3 endPos)
    {
        ScanningGrid.Node startNode = grid.NodeFromWorldPos(startPos);
        ScanningGrid.Node endNode = grid.NodeFromWorldPos(endPos);
        
        //why are the lists in here (local) and not set as normal?
        List<ScanningGrid.Node> openSet = new List<ScanningGrid.Node>();
        List<ScanningGrid.Node> closedSet = new List<ScanningGrid.Node>();
        
        openSet.Add(startNode);
        
        while (openSet.Count > 0)
        {
            //creates node for current space; assigns to list
            ScanningGrid.Node currentNode = openSet[0];
            //starts the loop at the neighbours
            for (int i = 1; i < openSet.Count; i++)
            {
                //if the fCost value is lower than the current node being checked OR if the same, finding closest to endNode
                if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                {
                    //set the smaller value node as currentNode 
                    currentNode = openSet[i];
                }
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
