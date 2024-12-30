using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1367
{
    public class Solution1367_3 : Interface1367
    {
        /// <summary>
        /// KMP
        /// 逻辑完全同Solution1367_2，只是将其中的字符串查找由API改为了KMP
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

            int[] next = GetNext(_path);
            foreach (string path in paths) if (KMP(path, _path, next) > -1) return true;
            return false;
        }

        private int KMP(string s, string t, int[] next)
        {
            if (s.Length < t.Length) return -1;
            if (s.Length == t.Length) return s == t ? 0 : -1;

            // int[] next = GetNext(t);
            int i = 0, j = 0, len_s = s.Length, len_t = t.Length;  // i是s的索引，j是t的索引
            while (len_s - i >= len_t - j)
            {
                while (i < len_s && j < len_t && s[i] == t[j]) { i++; j++; };

                if (j == len_t) return i - len_t;
                j = next[j];
                if (j == -1) { i++; j++; }
            }

            return -1;
        }

        private int[] GetNext(string s)
        {
            if (s.Length == 0) return new int[0];
            if (s.Length == 1) return new int[1] { -1 };
            if (s.Length == 2) return new int[2] { -1, 0 };

            int[] next = new int[s.Length]; next[0] = -1; next[1] = 0;
            int i = 2, j = 0;
            while (i < s.Length)
            {
                while (j >= 0 && s[i - 1] != s[j]) j = next[j];
                if (j == -1)
                {
                    if (s[i] != s[0]) next[i] = 0; else next[i] = -1;
                }
                else
                {
                    if (s[i] != s[j]) next[i] = j + 1; else next[i] = next[j];
                }
                i++; j++;
            }

            return next;
        }
    }
}
