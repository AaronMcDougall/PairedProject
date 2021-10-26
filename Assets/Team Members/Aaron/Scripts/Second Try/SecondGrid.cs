using System.Collections.Generic;
using UnityEngine;

namespace Team_Members.Aaron.Scripts.Second_Try
{
    public class SecondGrid : MonoBehaviour
    {
        public Transform player;
        public LayerMask layer;
        public Vector2Int worldSize;
    
        public int gridSizeX;
        public int gridSizeY;
        public int nodeSize = 1;
    
        List<Node> neighbours = new List<Node>();

        private GridNode[,] _gridNodes;
    
        void Start()
        {
            //how many grid spots in the world
            gridSizeX = Mathf.RoundToInt(worldSize.x / nodeSize);
            gridSizeY = Mathf.RoundToInt(worldSize.y / nodeSize);

            _gridNodes = new GridNode[worldSize.x, worldSize.y];
            CreateGrid();
            List<Node> neighbours = new List<Node>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        void CreateGrid()
        {
            _gridNodes = new GridNode[gridSizeX, gridSizeY];
            Vector3 worldBottomLeft =
                transform.position - Vector3.right * worldSize.x / 2 - Vector3.forward * worldSize.y / 2;
        
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    Vector3 worldPoint =
                        worldBottomLeft + Vector3.right * (x * nodeSize) + Vector3.forward * (y * nodeSize);
                    bool isBlocked = Physics.CheckBox(new Vector3(x, y, 0),
                        new Vector2(nodeSize, nodeSize), Quaternion.identity, layer);

                    _gridNodes[x, y] = new GridNode(isBlocked, worldPoint);

                }
            }
        }

        //get node from world point
        public GridNode NodeFromWorldPos(Vector3 worldPos)
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
            return _gridNodes[x,y];
        }

        private void OnDrawGizmos()
        {
            //drawing and filling grid
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    if (_gridNodes != null && _gridNodes[x, y].isBlocked)
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawCube(new Vector3(x, y, 0), Vector3.one * (nodeSize -0.1f));
                    }
                    else
                    {
                        Gizmos.color = Color.white;
                        Gizmos.DrawCube(new Vector3(x, y, 0), Vector3.one * (nodeSize -0.1f));
                    }

                    GridNode playerNode = NodeFromWorldPos(player.position);
                    foreach (var n in _gridNodes)
                    {
                        if (playerNode == n)
                        {
                            Gizmos.color = Color.cyan;
                        }
                    }
                }
            
            }
        }

    }
}
