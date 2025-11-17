using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0513
{
    public class Solution0513 : Interface0513
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int FindBottomLeftValue(TreeNode root)
        {
            int result = root.val;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int cnt; TreeNode item;
            while ((cnt = queue.Count) > 0)
            {
                result = queue.Peek().val;
                for (int i = 0; i < cnt; i++)
                {
                    item = queue.Dequeue();
                    if (item.left != null) queue.Enqueue(item.left);
                    if (item.right != null) queue.Enqueue(item.right);
                }
            }

            return result;
        }
    }
}
