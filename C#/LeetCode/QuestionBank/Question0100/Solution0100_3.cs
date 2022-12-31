using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0100
{
    public class Solution0100_3 : Interface0100
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;

            Queue<TreeNode> queue_p = new Queue<TreeNode>(); queue_p.Enqueue(p);
            Queue<TreeNode> queue_q = new Queue<TreeNode>(); queue_q.Enqueue(q);
            int cnt; while ((cnt = queue_p.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node_p = queue_p.Dequeue(), node_q = queue_q.Dequeue();
                    if (node_p.val != node_q.val) return false;
                    if (node_p.left != null && node_q.left != null)
                    {
                        queue_p.Enqueue(node_p.left); queue_q.Enqueue(node_q.left);
                    }
                    else if ((node_p.left != null && node_q.left == null) || (node_p.left == null && node_q.left != null))
                    {
                        return false;
                    }
                    if (node_p.right != null && node_q.right != null)
                    {
                        queue_p.Enqueue(node_p.right); queue_q.Enqueue(node_q.right);
                    }
                    else if ((node_p.right != null && node_q.right == null) || (node_p.right == null && node_q.right != null))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
