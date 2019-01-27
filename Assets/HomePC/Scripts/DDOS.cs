using System.Linq;
using UnityEngine;

namespace HomePC
{
    public class DDOS : MonoBehaviour
    {
        public Stats Stats;

        public Skill skill;

        // Start is called before the first frame update
        private void Start()
        {
            Stats = GetComponent<Stats>();
            skill = GetComponent<Skill>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision == null
                || skill.CurrentNode == null
                || collision.gameObject == skill.CurrentNode.gameObject)
                return;

            // Acheived waypoint. Switch next node.
            if (skill.NextInd >= 0
                && collision.gameObject == skill.Way[skill.NextInd].gameObject)
            {
                skill.CurrentNode = skill.Way[skill.NextInd];
                skill.NextInd += 1;

                if (skill.NextInd < skill.Way.Count)
                    skill.CalcCurVector();
                else
                    skill.CurVector = Vector3.zero;

                var other = collision.gameObject.GetComponentInChildren<Tool>();
                var firewall = other.skills.Select(x => x.GetComponent<Firewall>()).FirstOrDefault(x => x != null);
                if (firewall == null)
                {
                    var damage = Stats.Damage;
                    other.Stats.HP -= damage;
                }
                else
                {
                    Destroy(gameObject);
                }
            }

            // Reach target.
            if (collision.gameObject == skill.TargetNode.gameObject) Destroy(gameObject);
        }

        // Update is called once per frame
        private void Update()
        {
            if (skill.TargetNode != null && skill.NextInd >= 0) transform.position += skill.CurVector * Time.deltaTime;
        }
    }
}