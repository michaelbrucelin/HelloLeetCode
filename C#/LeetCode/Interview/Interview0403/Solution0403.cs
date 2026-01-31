using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0403
{
    public class Solution0403 : Interface0403
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public ListNode[] ListOfDepth(TreeNode tree)
        {
            if (tree == null) return [];
            List<ListNode> head = [], ptr = [];
            dfs(tree, 0);

            return [.. head];

            void dfs(TreeNode node, int depth)
            {
                if (node == null) return;
                if (head.Count == depth)
                {
                    head.Add(new ListNode(node.val)); ptr.Add(head[^1]);
                }
                else
                {
                    ptr[depth].next = new ListNode(node.val); ptr[depth] = ptr[depth].next;
                }
                dfs(node.left, depth + 1);
                dfs(node.right, depth + 1);
            }
        }
    }
}
