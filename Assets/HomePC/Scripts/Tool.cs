using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HomePC
{
    public class Tool : MonoBehaviour
    {
        public List<GameObject> skills;

        public Stats Stats;

        public void Start()
        {
            Stats = GetComponent<Stats>();
        }

        private void Update()
        {
            var hpText = "[";
            for (var i = 0; i < 10; i++)
                if (i < Stats.HP / 10)
                    hpText += "|";
                else
                    hpText += ".";
            GetComponentInChildren<Text>().text = hpText + "]";

            if (Stats.HP <= 0)
            {
                if (GetComponentInParent<Node>().player == 1)
                {
                    GetComponentInParent<Node>().player = 0;
                    GetComponentInChildren<Text>().color = Color.red;
                }

                else
                {
                    GetComponentInParent<Node>().player = 1;
                    GetComponentInChildren<Text>().color = Color.green;
                }

                Stats.HP = 50;
                Debug.Log("Объект захвачен");
            }

            if (GetComponentInParent<Node>().player == 1)
                GetComponentInChildren<Text>().color = Color.red;

            else
                GetComponentInChildren<Text>().color = Color.green;
        }
    }
}