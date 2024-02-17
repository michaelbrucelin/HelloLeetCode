using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0429
{
    public class Solution0429_2 : Interface0429
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(Node root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;
            dfs(root, 0, result);

            return result;
        }

        public void dfs(Node node, int level, IList<IList<int>> tree)
        {
            if (tree.Count == level) tree.Add(new List<int>());
            tree[level].Add(node.val);
            if (node.children != null) for (int i = 0; i < node.children.Count; i++)
                {
                    dfs(node.children[i], level + 1, tree);
                }
        }
    }
}
