using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1110
{
    public class Solution1110_2 : Interface1110
    {
        /// <summary>
        /// BFS
        /// 与Solution1110一样，采用双指针实现，不同的是这里使用BFS
        /// </summary>
        /// <param name="root"></param>
        /// <param name="to_delete"></param>
        /// <returns></returns>
        public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {
            List<TreeNode> result = new List<TreeNode>();
            HashSet<int> del = new HashSet<int>(to_delete) { -1 };
            TreeNode dummy = new TreeNode(-1);
            Queue<(TreeNode node, TreeNode parent, bool left)> queue = new Queue<(TreeNode node, TreeNode parent, bool left)>();
            queue.Enqueue((root, dummy, true));
            int cnt; while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    var t = queue.Dequeue();
                    if (del.Contains(t.node.val))
                    {
                        if (t.left) t.parent.left = null; else t.parent.right = null;
                    }
                    else  // if(!del.Contains(t.node.val))
                    {
                        if (del.Contains(t.parent.val)) result.Add(t.node);
                    }

                    if (t.node.left != null) queue.Enqueue((t.node.left, t.node, true));
                    if (t.node.right != null) queue.Enqueue((t.node.right, t.node, false));
                }
            }

            return result;
        }
    }
}
