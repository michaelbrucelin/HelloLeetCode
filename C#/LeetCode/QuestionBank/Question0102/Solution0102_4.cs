using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0102
{
    public class Solution0102_4 : Interface0102
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            Stack<(int level, TreeNode node)> stack = new Stack<(int, TreeNode)>();
            int level = 0; TreeNode ptr = root;
            while (ptr != null || stack.Count > 0)
            {
                while (ptr != null)
                {
                    if (level == result.Count) result.Add(new List<int>());
                    result[level].Add(ptr.val); stack.Push((level, ptr)); ptr = ptr.left; level++;
                }
                var item = stack.Pop();
                ptr = item.node.right;
                level = item.level + 1;
            }

            return result;
        }
    }
}
