using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0112
{
    public class Solution0112_2 : Interface0112
    {
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null) return false;

            Queue<TreeNode> queue1 = new Queue<TreeNode>(); queue1.Enqueue(root);
            Queue<int> queue2 = new Queue<int>(); queue2.Enqueue(root.val);
            int cnt; while ((cnt = queue1.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = queue1.Dequeue();
                    int sum = queue2.Dequeue();
                    if (node.left == null && node.right == null)
                    {
                        if (sum == targetSum) return true;
                    }
                    else
                    {
                        if (node.left != null) { queue1.Enqueue(node.left); queue2.Enqueue(sum + node.left.val); }
                        if (node.right != null) { queue1.Enqueue(node.right); queue2.Enqueue(sum + node.right.val); }
                    }
                }
            }

            return false;
        }
    }
}
