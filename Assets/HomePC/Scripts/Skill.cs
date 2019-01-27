using System.Collections.Generic;
using UnityEngine;

namespace HomePC
{
    public class Skill : MonoBehaviour
    {
        public Node CurrentNode;

        public Node TargetNode;

        public int NextInd = -1;

        public List<Node> Way;

        public bool RequiresTarget = false;

        public Vector3 CurVector;

        // Start is called before the first frame update
        private void Start()
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 17;
        }

        // Update is called once per frame
        private void Update()
        {
            if (NextInd < 0
                && CurrentNode != null
                && TargetNode != null
                && CurrentNode != TargetNode)
            {
                Way = new List<Node>();
                if (PathBuilder.FindPath(CurrentNode, TargetNode, Way))
                {
                    Way.Reverse();
                    NextInd = 1;
                    CalcCurVector();
                }
                else
                {
                    Way = null;
                }
            }
        }

        public void CalcCurVector()
        {
            CurVector = Way[NextInd].transform.position - transform.position;
        }
    }
}