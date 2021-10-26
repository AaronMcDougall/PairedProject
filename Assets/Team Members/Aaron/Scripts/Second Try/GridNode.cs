using UnityEngine;

namespace Team_Members.Aaron.Scripts.Second_Try
{
    public class GridNode : MonoBehaviour
    {
        public Vector3 worldPosition;
        public bool isBlocked;

        public int gridX;
        public int gridY;
        public int gCost;
        public int hCost;

        public Node parent;

        public GridNode(bool _isBlocked, Vector3 _worldPosition)
        {
            isBlocked = _isBlocked;
            worldPosition = _worldPosition;
        }
        public int fCost
        {
            get { return gCost + hCost; }
        }
    }
}
