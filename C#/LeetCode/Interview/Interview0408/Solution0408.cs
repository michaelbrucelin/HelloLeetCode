using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0408
{
    public class Solution0408 : Interface0408
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            return rec(root).Item1;

            (TreeNode, bool, bool) rec(TreeNode node)
            {
                if (node == null) return (null, false, false);

                (TreeNode, bool, bool) linfo = rec(node.left);
                if (linfo.Item1 != null) return (linfo.Item1, false, false);
                (TreeNode, bool, bool) rinfo = rec(node.right);
                if (rinfo.Item1 != null) return (rinfo.Item1, false, false);

                if ((linfo.Item2 || rinfo.Item2) && (linfo.Item3 || rinfo.Item3)) return (node, false, false);
                if (node == p && (linfo.Item3 || rinfo.Item3)) return (node, false, false);
                if (node == q && (linfo.Item2 || rinfo.Item2)) return (node, false, false);

                return (null, node == p || linfo.Item2 || rinfo.Item2, node == q || linfo.Item3 || rinfo.Item3);
            }
        }
    }
}
