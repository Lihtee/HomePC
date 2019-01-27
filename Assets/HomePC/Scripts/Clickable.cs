using UnityEngine;

namespace HomePC
{
    public class Clickable : MonoBehaviour
    {
        public PlayerManager pm;

        public GameObject current;
        public GameObject target;


        public void OnMouseDown()
        {
            var n = GetComponent<Node>();
            if (n != null)
            {
                Debug.Log(n.name);
                if (pm.currentNode == null)
                {
                    pm.currentNode = n;
                    current.transform.position = new Vector3(n.transform.position.x, n.transform.position.y, 1);
                }

                else
                {
                    pm.targetNode = n;
                    target.transform.position = new Vector3(n.transform.position.x, n.transform.position.y, 1);
                }
            }
        }
    }
}