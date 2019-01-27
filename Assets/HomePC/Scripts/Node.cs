using UnityEngine;

namespace HomePC
{
    public class Node : MonoBehaviour
    {
        public int id;
        public int player;
        public Tool tool;

        public Node[] connections;

        private void Start()
        {
            tool = GetComponentInChildren<Tool>();
        }
    }
}