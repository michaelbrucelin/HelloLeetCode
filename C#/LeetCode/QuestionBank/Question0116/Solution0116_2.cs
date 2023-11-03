using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0116
{
    public class Solution0116_2 : Interface0116
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node Connect(Node root)
        {
            if (root == null || root.left == null) return root;

            root.left.next = root.right;

            return root;
        }
    }
}
