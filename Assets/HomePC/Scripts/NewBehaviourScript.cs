using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HomePC
{
    public class NewBehaviourScript : MonoBehaviour
    {
        public PlayerManager pm;

        private GameObject t;

        private bool spawned;

        public GameObject container;

        public GameObject current;
        public GameObject target;

        private void FixedUpdate()
        {
            if (spawned)
                if (pm.currentNode != null)
                {
                    var skill = t.GetComponent<Skill>();
                    if (!skill.RequiresTarget || pm.targetNode != null)
                    {
                        skill.CurrentNode = pm.currentNode;
                        skill.TargetNode = pm.targetNode;
                        t.transform.position = pm.currentNode.transform.position;

                        if (!skill.RequiresTarget)
                        {
                            skill.CurrentNode.tool.skills.Add(t);
                            var limit = 0.3f;
                            var shift = 0.5f;
                            var xRnd = Random.Range(-limit, limit);
                            xRnd = xRnd > 0
                                ? xRnd + shift
                                : xRnd - shift;
                            var yRnd = Random.Range(-limit, limit);
                            yRnd = yRnd > 0
                                ? yRnd + shift
                                : yRnd - shift;

                            t.transform.position += new Vector3(xRnd, yRnd, 0);
                        }

                        var ddos = t.GetComponent<DDOS>();
                        if (ddos != null)
                        {
                            var path = new List<Node>();
                            var finishNode = PathBuilder.FindPath(skill.CurrentNode, skill.TargetNode, path);
                            if (path.FirstOrDefault() != finishNode)
                            {
                                Debug.Log("Wrong pathFinding: expexted " + skill.TargetNode.name + ", actual: " +
                                          path.FirstOrDefault());
                            }
                            else
                            {
                                path.Reverse();
                                var msg =
                                    $"Correct way, but still probably not the best.  .{string.Join("->", path.Select(y => $"{y.name}"))}";
                                Debug.Log(msg);
                            }

                            t.transform.position = pm.currentNode.transform.position;


                            for (var i = 0; i < 20; i++)
                            {
                                var ddosPart = Instantiate(t).GetComponent<Skill>();
                                ddosPart.CurrentNode = pm.currentNode;
                                ddosPart.TargetNode = pm.targetNode;
                                ddosPart.transform.position = pm.currentNode.transform.position
                                                              + new Vector3(Random.Range(-2f, 2f),
                                                                  Random.Range(-2f, 2f), 0);
                            }
                        }

                        spawned = false;
                        current.transform.position = new Vector3(500, 500, 500);
                        target.transform.position = new Vector3(500, 500, 500);
                        pm.currentNode = null;
                        pm.targetNode = null;
                    }
                }
        }

        public void Spawn(GameObject p)
        {
            if (pm.money >= p.GetComponent<Stats>().Cost)
            {
                var t = Instantiate(p);
                pm.money -= p.GetComponent<Stats>().Cost;

                spawned = true;
                this.t = t;
            }
        }
    }
}