using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0404
{
    public class Solution0404_2 : Interface0404
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null) return 0;

            int result = 0;
            Queue<TreeNode> queue1 = new Queue<TreeNode>(); queue1.Enqueue(root);
            Queue<bool> queue2 = new Queue<bool>(); queue2.Enqueue(false);
            int cnt; while ((cnt = queue1.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = queue1.Dequeue();
                    bool isleft = queue2.Dequeue();
                    if (node.left == null && node.right == null)
                    {
                        if (isleft) result += node.val;
                    }
                    else
                    {
                        if (node.left != null) { queue1.Enqueue(node.left); queue2.Enqueue(true); }
                        if (node.right != null) { queue1.Enqueue(node.right); queue2.Enqueue(false); }
                    }
                }
            }

            return result;
        }
    }
}
