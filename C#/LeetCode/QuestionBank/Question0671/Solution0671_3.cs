using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0671
{
    public class Solution0671_3 : Interface0671
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int FindSecondMinimumValue(TreeNode root)
        {
            if (root.left == null) return -1;  // 题目限定必然root.right == null

            int result = int.MaxValue, min = root.val; TreeNode node; bool flag = false;
            Queue<TreeNode> queue = new Queue<TreeNode>(); queue.Enqueue(root.left); queue.Enqueue(root.right);
            int cnt; while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    node = queue.Dequeue();
                    if (node.val > min)
                    {
                        result = Math.Min(result, node.val); flag = true;
                        if (result == node.val + 1) return result;
                    }
                    else if (node.left != null)
                    {
                        queue.Enqueue(node.left); queue.Enqueue(node.right);
                    }
                }
            }

            return flag ? result : -1;
        }
    }
}
