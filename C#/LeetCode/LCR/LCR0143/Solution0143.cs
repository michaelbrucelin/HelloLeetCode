using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0143
{
    public class Solution0143 : Interface0143
    {
        /// <summary>
        /// DFS
        /// DFS预处理出A B两棵树每个节点左右子树的中节点的数量，然后再DFS比较
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public bool IsSubStructure(TreeNode A, TreeNode B)
        {
            if (A == null || B == null) return false;

            Dictionary<TreeNode, (int, int)> mapa = new Dictionary<TreeNode, (int, int)>(), mapb = new Dictionary<TreeNode, (int, int)>();
            if (dfs_init(A, mapa) < dfs_init(B, mapb)) return false;
            return dfs(A, B, mapa, mapb);

            static bool dfs(TreeNode node, TreeNode target, Dictionary<TreeNode, (int, int)> map1, Dictionary<TreeNode, (int, int)> map2)
            {
                if (target == null) return true;
                if (node == null) return false;
                if (map1[node].Item1 < map2[target].Item1 || map1[node].Item2 < map2[target].Item2) return false;

                bool flagl, flagr;
                if (node.val == target.val)
                {
                    flagl = dfs(node.left, target.left, map1, map2);    // 这里可以通过“短路”与“小驱动大”来优化，这里先不这样做
                    flagr = dfs(node.right, target.right, map1, map2);
                    if (flagl && flagr) return true;
                }

                if (dfs(node.left, target, map1, map2)) return true;
                if (dfs(node.right, target, map1, map2)) return true;

                return false;
            }

            static int dfs_init(TreeNode node, Dictionary<TreeNode, (int, int)> map)
            {
                if (node == null) return 0;

                int lcnt = dfs_init(node.left, map);
                int rcnt = dfs_init(node.right, map);
                map.Add(node, (lcnt, rcnt));

                return lcnt + rcnt + 1;
            }
        }
    }
}
