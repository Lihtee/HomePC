using System;
using UnityEngine;
using UnityEngine.UI;

namespace HomePC
{
    public class PlayerManager : MonoBehaviour
    {
        public int money;
        public string name;
        public int captured;
        private DateTime startTime;

        public Text nameUI;
        public Text moneyUI;
        public Text capturedUI;
        public Text timeUI;
        public Text sideUI;

        public Node currentNode;
        public Node targetNode;

        private GameObject[] nodeList;

        // Start is called before the first frame update
        private void Start()
        {
            currentNode = null;
            money = 500;
            name = "mrak77";
            startTime = DateTime.Now;
            captured = 0;
            nodeList = GameObject.FindGameObjectsWithTag("Node");

            nameUI.text = "Nickname: " + name;
            moneyUI.text = "Bitcoins: " + money;
            capturedUI.text = "Captured: " + captured;
            timeUI.text = "Time: " + (DateTime.Now - startTime).Minutes + ":" + (DateTime.Now - startTime).Seconds;
            sideUI.text = "Side: " + "Defence";
        }

        private void Update()
        {
            captured = 0;
            foreach (var n in nodeList)
                if (n.GetComponent<Node>().player == 0)
                {
                    captured++;
                }
                else
                {
                    var isNeighbour = false;
                    foreach (var nod in n.GetComponent<Node>().connections)
                        if (nod.player == 0)
                        {
                            isNeighbour = true;
                            break;
                        }

                    if (!isNeighbour)
                    {
                    }
                }

            moneyUI.text = "Bitcoins: " + money;
            capturedUI.text = "Captured: " + captured;
            timeUI.text = "Time: " + (DateTime.Now - startTime).Minutes + ":" + (DateTime.Now - startTime).Seconds;
        }

        public void onTowerAttackClick(int i)
        {
        }
    }
}