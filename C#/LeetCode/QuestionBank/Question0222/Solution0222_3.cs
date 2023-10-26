using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LeetCode.QuestionBank.Question0222
{
    public class Solution0222_3 : Interface0222
    {
        /// <summary>
        /// 充分利用完全二叉树的定义
        /// 1. 从根节点一直向左查找，可以找出完全二叉树有多少层
        /// 2. BFS，加载到倒数第二层时，逐个元素检查有没有左右孩子
        /// 时间复杂度和空间复杂度都可以将为O(N/2)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int CountNodes(TreeNode root)
        {
            if (root == null) return 0;

            int level = 0; TreeNode ptr = root;
            while (ptr != null) { level++; ptr = ptr.left; }
            if (level == 1) return 1;

            int result = (1 << (level - 1)) - 1, cnt;
            Queue<TreeNode> queue = new Queue<TreeNode>(); queue.Enqueue(root);
            while (--level > 1)
            {
                cnt = queue.Count; for (int i = 0; i < cnt; i++)
                {
                    ptr = queue.Dequeue(); queue.Enqueue(ptr.left); queue.Enqueue(ptr.right);
                }
            }

            while (queue.Count > 0)
            {
                ptr = queue.Dequeue();
                if (ptr.left != null) result++; else break;
                if (ptr.right != null) result++; else break;
            }

            return result;
        }
    }
}
