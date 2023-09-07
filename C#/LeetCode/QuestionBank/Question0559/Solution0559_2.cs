using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0559
{
    public class Solution0559_2 : Interface0559
    {
        /// <summary>
        /// DFS, 有返回值
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(Node root)
        {
            if (root == null) return 0;

            int depth = 0;
            for (int i = 0; i < root.children.Count; i++)
                depth = Math.Max(depth, MaxDepth(root.children[i]));

            return depth + 1;
        }
    }
}
