using LeetCode.QuestionBank.Question0559;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0222
{
    public class Solution0222_2 : Interface0222
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int CountNodes(TreeNode root)
        {
            if (root == null) return 0;

            int result = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>(); queue.Enqueue(root);
            TreeNode node;
            while (queue.Count > 0)
            {
                node = queue.Dequeue(); result++;
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            return result;
        }
    }
}
