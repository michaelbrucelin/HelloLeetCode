using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0056
{
    public class Solution0056_3 : Interface0056
    {
        /// <summary>
        /// 同Solution0056_2，既然将树序列化为链表，还不如直接序列化为hash表
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool FindTarget(TreeNode root, int k)
        {
            if (root == null) return false;

            HashSet<int> set = new HashSet<int>();
            dfs(root, set);
            foreach (int i in set)
            {
                if ((i << 1) == k) continue; else if (set.Contains(k - i)) return true;
            }

            return false;
        }

        private void dfs(TreeNode root, HashSet<int> list)
        {
            if (root == null) return;
            dfs(root.left, list);
            list.Add(root.val);
            dfs(root.right, list);
        }
    }
}
