using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0235
{
    public class Solution0235 : Interface0235
    {
        /// <summary>
        /// 递归
        /// 由于是二叉搜索树，所以
        ///     如果 p = q，那个p就是最近公共祖先
        ///     如果p, q，一个比根大，一个比根小，那个根就是最近公共祖先
        ///     如果p, q都比根小，那个递归左子树
        ///     如果p, q都比根大，那个递归右子树
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (p == root || q == root) return root;
            if (p.val == q.val) return p;
            // if ((p.val - root.val) * (q.val - root.val) < 0) 担心会溢出
            if ((p.val < root.val && q.val > root.val) || (p.val > root.val && q.val < root.val)) return root;
            return (p.val < root.val && q.val < root.val) ? LowestCommonAncestor(root.left, p, q) : LowestCommonAncestor(root.right, p, q);
        }
    }
}
