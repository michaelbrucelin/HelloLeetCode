using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1379
{
    public class Solution1379_2 : Interface1379
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="original"></param>
        /// <param name="cloned"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(cloned);
            int cnt; while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (node.val == target.val) return node;
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }

            throw new Exception("logic error!");
        }
    }
}
