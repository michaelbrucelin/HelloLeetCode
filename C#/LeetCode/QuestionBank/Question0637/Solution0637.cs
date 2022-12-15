using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0637
{
    public class Solution0637 : Interface0637
    {
        public IList<double> AverageOfLevels(TreeNode root)
        {
            List<double> result = new List<double>();
            if (root == null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int cnt; while ((cnt = queue.Count) > 0)
            {
                double sum = 0;
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = queue.Dequeue();
                    sum += node.val;
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                result.Add(sum / cnt);
            }

            return result;
        }
    }
}
