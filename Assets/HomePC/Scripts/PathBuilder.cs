using System.Collections.Generic;

namespace HomePC
{
    public class PathBuilder
    {
        public static bool FindPath(Node cur, Node finish, List<Node> res, List<Node> used = null)
        {
            if (used == null) used = new List<Node>();

            if (res == null) res = new List<Node>();

            if (cur == finish)
            {
                res.Add(cur);
                return true;
            }

            foreach (var node in cur.connections)
            {
                if (used.Contains(node)) continue;

                used.Add(node);
                if (FindPath(node, finish, res, used))
                {
                    res.Add(cur);
                    return true;
                }
            }

            used.Remove(cur);
            return false;
        }
    }
}