using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1367
{
    public class Solution1367_2 : Interface1367
    {
        /// <summary>
        /// 预处理
        /// 预处理出树中全部可能路径的字符串，在预处理链表的字符串，然后进行字符串查找即可。
        /// 如果字符串查找采用暴力查找，那么时间复杂度与Solution1367是一样的，这里直接使用API提供的方法，继续加速可以手写KMP
        /// </summary>
        /// <param name="head"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSubPath(ListNode head, TreeNode root)
        {
            List<string> paths = new List<string>();
            Queue<(TreeNode node, List<int> path)> queue = new Queue<(TreeNode node, List<int> path)>();
            queue.Enqueue((root, new List<int>() { root.val }));
            (TreeNode node, List<int> path) item;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                if (item.node.left == null && item.node.right == null)
                {
                    paths.Add($",{string.Join(',', item.path)},");
                }
                else
                {
                    if (item.node.left != null) queue.Enqueue((item.node.left, new List<int>(item.path) { item.node.left.val }));
                    if (item.node.right != null) queue.Enqueue((item.node.right, new List<int>(item.path) { item.node.right.val }));
                }
            }

            List<int> list = new List<int>();
            ListNode dummy = new ListNode(0) { next = head };
            while ((dummy = dummy.next) != null) list.Add(dummy.val);
            string _path = $",{string.Join(',', list)},";

            foreach (string path in paths) if (path.Contains(_path)) return true;
            return false;
        }
    }
}
