using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class Pathfinding : MonoBehaviour
{
    public Transform beginning, finish;

    private Vector3 beginningPos;

    private int distanceX;
    private int distanceY;

    //ref to Grid
    public List<ScanningGrid.Node> openSet = new List<ScanningGrid.Node>();
    public List<ScanningGrid.Node> closedSet = new List<ScanningGrid.Node>();

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

        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            ScanningGrid.Node currentNode = openSet[0];

            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < currentNode.fCost ||
                    openSet[i].fCost < currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                {
                    currentNode = openSet[i];
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == endNode)
            {
                return;
            }

            foreach (var neighbour in grid.GetNeighbours(currentNode))
            {
                if (neighbour.isBlocked || closedSet.Contains(neighbour))
                {
                    continue;
                }

                int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);

                if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = newMovementCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, endNode);
                    neighbour.parent = currentNode;


                    if (!openSet.Contains(neighbour))
                    {
                        openSet.Add(neighbour);
                        return;
                    }
                }
            }
        }
    }


    int GetDistance(ScanningGrid.Node nodeA, ScanningGrid.Node nodeB)
    {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        Debug.Log("A = " + nodeA.gridX);
        Debug.Log("B = " + nodeB.gridX);

        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (dstX < dstY)
        {
            return 14 * dstY + 10 * dstX;
        }
        else
        {
            return 14 * dstX + 10 * dstY;
        }
    }

    void RetracePath(ScanningGrid.Node startNode, ScanningGrid.Node endNode)
    {
        List<ScanningGrid.Node> path = new List<ScanningGrid.Node>();
        ScanningGrid.Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }

        path.Reverse();
    }
}