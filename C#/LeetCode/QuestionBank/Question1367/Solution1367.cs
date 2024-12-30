using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1367
{
    public class Solution1367 : Interface1367
    {
        /// <summary>
        /// DFS
        /// TLE，参考测试用例04,05
        /// </summary>
        /// <param name="head"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSubPath(ListNode head, TreeNode root)
        {
            return dfs(head, root);

            bool dfs(ListNode plist, TreeNode ptree)
            {
                if (plist == null) return true;
                if (ptree == null) return false;
                if (ptree.val == plist.val)
                {
                    if (dfs(plist.next, ptree.left) || dfs(plist.next, ptree.right)) return true;
                }
                if (dfs(head, ptree.left)) return true;   // 这里产生了大量的重复查询，导致的TLE
                if (dfs(head, ptree.right)) return true;  // 这里产生了大量的重复查询，导致的TLE

                return false;
            }
        }

        /// <summary>
        /// IsSubPath() TLE了，看代码与官解差不多，但是官解时间复杂度却击败了100%
        /// 看代码怀疑是操作顺序的一点差异，IsSubPath()导致了大量的重复查询，如果真的是这样，可以通过记忆化搜索来解决，这里验证一下
        /// 果然如此，功力还是不够深啊。。。
        /// </summary>
        /// <param name="head"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSubPath2(ListNode head, TreeNode root)
        {
            HashSet<(ListNode, TreeNode)> memory = new HashSet<(ListNode, TreeNode)>();
            return dfs(head, root);

            bool dfs(ListNode plist, TreeNode ptree)
            {
                if (memory.Contains((plist, ptree))) return false;
                if (plist == null) return true;
                if (ptree == null) return false;
                if (ptree.val == plist.val)
                {
                    // if (dfs(plist.next, ptree.left) || dfs(plist.next, ptree.right)) return true;
                    if (dfs(plist.next, ptree.left)) return true; else memory.Add((plist.next, ptree.left));
                    if (dfs(plist.next, ptree.right)) return true; else memory.Add((plist.next, ptree.right));
                }
                if (dfs(head, ptree.left)) return true; else memory.Add((head, ptree.left));
                if (dfs(head, ptree.right)) return true; else memory.Add((head, ptree.right));

                return false;
            }
        }
    }
}
