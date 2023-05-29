using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0590
{
    public class Solution0590 : Interface0590
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Postorder(Node root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;

            for (int i = 0; i < root.children.Count; i++)
                result.AddRange(Postorder(root.children[i]));
            result.Add(root.val);

            return result;
        }

        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Postorder2(Node root)
        {
            List<int> result = new List<int>();
            dfs(root, result);

            return result;
        }

        private void dfs(Node node, List<int> result)
        {
            if (node == null) return;
            for (int i = 0; i < node.children.Count; i++)
                dfs(node.children[i], result);
            result.Add(node.val);
        }
    }
}
