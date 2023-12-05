using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0501
{
    public class Solution0501_err : Interface0501
    {
        /// <summary>
        /// 分析
        /// 利用好二叉搜索树这一条件，当一个节点的左右子节点的值都不等于当前节点时，再往后也不会有相同值的节点了
        /// 
        /// 解法时错误的，参考测试用例03
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int[] FindMode(TreeNode root)
        {
            int max = 0; List<int> result = new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                var t = rec(node, node.val);
                switch (t.cnt - max)
                {
                    case > 0:
                        result.Clear(); result.Add(node.val); max = t.cnt;
                        break;
                    case 0:
                        result.Add(node.val);
                        break;
                    default:
                        break;
                }
                if (t.lt != null) queue.Enqueue(t.lt);
                if (t.gt != null) queue.Enqueue(t.gt);
            }

            return result.ToArray();
        }

        /// <summary>
        /// 返回值除了当前节点值的数目外，还要返回接下来要查找的节点（可以证明，至多两个）
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private (int cnt, TreeNode lt, TreeNode gt) rec(TreeNode node, int val)
        {
            if (node == null) return (0, null, null);
            if (node.val != val) return (0, node, node);

            var tl = rec(node.left, val);
            var tr = rec(node.right, val);
            return (1 + tl.cnt + tr.cnt, tl.lt, tr.gt);
        }
    }
}
