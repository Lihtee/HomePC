using System.Linq;
using UnityEngine;

namespace HomePC
{
    public class Virus : MonoBehaviour
    {
        public Stats Stats;
        public Skill skill;
        public PlayerManager pm;

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

            if (collision.gameObject == skill.TargetNode.gameObject)
            {
                var other = collision.gameObject.GetComponentInChildren<Tool>();
                var anVirus = other.skills.Select(x => x.GetComponent<Antivirus>()).FirstOrDefault(x => x != null);
                if (anVirus != null)
                {
                    if (Random.Range(0, 100000) > 100000 * anVirus.prob)
                    {
                        var damage = Stats.Damage;
                        other.Stats.HP -= damage;
                    }
                }
                else
                {
                    var damage = Stats.Damage;
                    other.Stats.HP -= damage;
                }

                Destroy(gameObject);
            }
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