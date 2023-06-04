using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1379
{
    public class Solution1379_4 : Interface1379
    {
        /// <summary>
        /// BFS
        /// 进阶的解法，同时遍历两棵树
        /// </summary>
        /// <param name="original"></param>
        /// <param name="cloned"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            Queue<TreeNode> queue1 = new Queue<TreeNode>(), queue2 = new Queue<TreeNode>();
            queue1.Enqueue(original); queue2.Enqueue(cloned);
            int cnt; while ((cnt = queue1.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node1 = queue1.Dequeue(), node2 = queue2.Dequeue();
                    if (node1 == target) return node2;
                    if (node1.left != null) { queue1.Enqueue(node1.left); queue2.Enqueue(node2.left); }
                    if (node1.right != null) { queue1.Enqueue(node1.right); queue2.Enqueue(node2.right); }
                }
            }

            throw new Exception("logic error!");
        }
    }
}
