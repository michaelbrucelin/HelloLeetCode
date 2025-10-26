using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0194
{
    public class Solution0194 : Interface0194
    {
        /// <summary>
        /// 两轮回溯
        /// 到主库的0236题去提交验证
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            List<TreeNode> listp = new List<TreeNode>();
            backtrack(root, p, listp);
            List<TreeNode> listq = new List<TreeNode>();
            backtrack(root, q, listq);
            if (listp.Count > listq.Count) (listp, listq) = (listq, listp);
            HashSet<TreeNode> setq = [.. listq];
            int i = 1;
            for (; i < listp.Count && setq.Contains(listp[i]); i++) ;
            return listp[i - 1];

            bool backtrack(TreeNode curr, TreeNode target, List<TreeNode> list)
            {
                if (curr == null) return false;
                list.Add(curr);
                if (curr == target) return true;

                bool flag;
                flag = backtrack(curr.left, target, list);
                if (flag) return true;
                flag = backtrack(curr.right, target, list);
                if (flag) return true;
                list.RemoveAt(list.Count - 1);
                return false;
            }
        }
    }
}
