using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0559
{
    public class Solution0559 : Interface0559
    {
        /// <summary>
        /// DFS, 无返回值
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(Node root)
        {
            int result = 0;
            dfs(root, 0, ref result);

            return result;
        }

        private void dfs(Node node, int depth, ref int result)
        {
            if (node == null) return;

            result = Math.Max(result, ++depth);
            for (int i = 0; i < node.children.Count; i++)
                dfs(node.children[i], depth, ref result);
        }
    }
}
