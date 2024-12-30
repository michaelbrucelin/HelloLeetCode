using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1367
{
    public class Solution1367_off : Interface1367
    {
        /// <summary>
        /// 感觉时间复杂度上与Solution1367一样，但是Solution1367 TLE了，有时间再细看看
        /// Solution1367中产生了大量的重复调用，如果一定要那么写，需要借助记忆化搜索才可以
        /// </summary>
        /// <param name="head"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSubPath(ListNode head, TreeNode root)
        {
            if (root == null) return false;
            return dfs(root, head) || IsSubPath(head, root.left) || IsSubPath(head, root.right);

            bool dfs(TreeNode ptree, ListNode plist)
            {
                if (plist == null) return true;
                if (ptree == null) return false;
                if (ptree.val != plist.val) return false;
                return dfs(ptree.left, plist.next) || dfs(ptree.right, plist.next);
            }
        }
    }
}
