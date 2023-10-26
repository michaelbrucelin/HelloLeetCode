using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1022
{
    public class Solution1022_3 : Interface1022
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int SumRootToLeaf(TreeNode root)
        {
            if (root == null) return 0;
            Queue<TreeNode> queue1 = new Queue<TreeNode>(); queue1.Enqueue(root);
            Queue<int> queue2 = new Queue<int>(); queue2.Enqueue(0);

            int result = 0, value; TreeNode node;
            while (queue2.Count > 0)
            {
                node = queue1.Dequeue(); value = (queue2.Dequeue() << 1) | node.val;
                if (node.left == null && node.right == null) result += value;
                else if (node.left == null)
                {
                    queue1.Enqueue(node.right); queue2.Enqueue(value);
                }
                else if (node.right == null)
                {
                    queue1.Enqueue(node.left); queue2.Enqueue(value);
                }
                else
                {
                    queue1.Enqueue(node.left); queue2.Enqueue(value);
                    queue1.Enqueue(node.right); queue2.Enqueue(value);
                }
            }

            return result;
        }
    }
}
