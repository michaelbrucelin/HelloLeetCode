using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0102
{
    public class Solution0102 : Interface0102
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root); int cnt = 0;
            while ((cnt = queue.Count) > 0)
            {
                List<int> list = new List<int>();
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = queue.Dequeue();
                    list.Add(node.val);
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                result.Add(list);
            }

            return result;
        }
    }
}
