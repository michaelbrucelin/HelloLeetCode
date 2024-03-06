using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0404
{
    public class Solution0404_err : Interface0404
    {
        /// <summary>
        /// BFS
        /// 查找最高子树与最矮子树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;

            int min = -1, level = 0, cnt;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            TreeNode node;
            while ((cnt = queue.Count) > 0)
            {
                level++;
                for (int i = 0; i < cnt; i++)
                {
                    node = queue.Dequeue();
                    if (node.left == null && node.right == null)
                    {
                        if (min == -1) min = level;
                    }
                    else
                    {
                        if (node.left != null) queue.Enqueue(node.left);
                        if (node.right != null) queue.Enqueue(node.right);
                    }
                }
                if (min != -1 && level - min > 1) return false;
            }

            return true;
        }
    }
}
