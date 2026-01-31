using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0403
{
    public class Solution0403_2 : Interface0403
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public ListNode[] ListOfDepth(TreeNode tree)
        {
            if (tree == null) return [];
            List<ListNode> list = [];
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(tree);
            int cnt; ListNode dummy = new ListNode(), ptr; TreeNode item;
            while ((cnt = queue.Count) > 0)
            {
                ptr = dummy;
                for (int i = 0; i < cnt; i++)
                {

                    item = queue.Dequeue();
                    ptr.next = new ListNode(item.val); ptr = ptr.next;
                    if (item.left != null) queue.Enqueue(item.left);
                    if (item.right != null) queue.Enqueue(item.right);
                }
                list.Add(dummy.next);
            }

            return [.. list];
        }
    }
}
