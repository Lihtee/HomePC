using System.Linq;
using UnityEngine;

namespace HomePC
{
    public class Miner : MonoBehaviour
    {
        public Stats Stats;
        public Skill skill;
        public int waitStep = 10;

        // Start is called before the first frame update
        private void Start()
        {
            Stats = GetComponent<Stats>();
            skill = GetComponent<Skill>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision == null
                || skill.CurrentNode == null
                || collision.gameObject == skill.CurrentNode.gameObject)
                return;

            if (collision.gameObject == skill.TargetNode.gameObject)
            {
                if (waitStep == 0)
                {
                    var other = collision.gameObject.GetComponentInChildren<Tool>();
                    var anVirus = other.skills.Select(x => x.GetComponent<Antivirus>()).FirstOrDefault(x => x != null);
                    if (anVirus != null)
                    {
                        if (Random.Range(0, 100) > 10)
                            GameObject.FindGameObjectsWithTag("PlayerTag")[0].GetComponent<PlayerManager>().money += 20;
                        else
                            Destroy(gameObject);
                    }
                    else
                    {
                        GameObject.FindGameObjectsWithTag("PlayerTag")[0].GetComponent<PlayerManager>().money += 20;
                    }

                    waitStep = 10;
                }
                else
                {
                    waitStep--;
                }


                //
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
        }

        // Update is called once per frame
        private void Update()
        {
            if (skill.TargetNode != null)
                transform.position = Vector3.Lerp(transform.position, skill.TargetNode.transform.position,
                    0.3f * Time.deltaTime);
        }
    }
}