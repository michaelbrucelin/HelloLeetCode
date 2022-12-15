using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0102
{
    public class Solution0102_5 : Interface0102
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            Stack<(bool tag, int level, TreeNode node)> stack = new Stack<(bool, int, TreeNode)>();  // true:白色, false:灰色
            int level = 0;
            stack.Push((true, level, root));
            while (stack.Count > 0)
            {
                var item = stack.Pop();
                int _level = item.level; TreeNode _node = item.node;
                if (_node == null) continue;
                if (item.tag)
                {
                    stack.Push((true, _level + 1, _node.right));
                    stack.Push((true, _level + 1, _node.left));
                    stack.Push((false, _level, _node));
                }
                else
                {
                    if (_level == result.Count) result.Add(new List<int>());
                    result[_level].Add(_node.val);
                }
            }

            return result;
        }
    }
}
