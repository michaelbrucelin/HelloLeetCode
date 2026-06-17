using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0450
{
    public class Solution0450 : Interface0450
    {
        /// <summary>
        /// 模拟
        /// 要么将右子树挂到左子树右下角的节点上，要么将左子树挂到右子树左下角的节点上
        /// 这里将较高的子树挂到较矮的子树上，对于本题，更快，对于二叉搜索树，不友好
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null) return root;

            TreeNode dummy = new TreeNode(Math.Max(root.val, key) + 1, root, null);
            TreeNode fa = dummy, ptr = root; bool lchid = true;
            while (ptr != null)
            {
                if (key < ptr.val) { fa = ptr; ptr = ptr.left; lchid = true; continue; }
                if (key > ptr.val) { fa = ptr; ptr = ptr.right; lchid = false; continue; }
                // ptr.val == key
                if (ptr.left == null) { if (lchid) fa.left = ptr.right; else fa.right = ptr.right; break; }
                if (ptr.right == null) { if (lchid) fa.left = ptr.left; else fa.right = ptr.left; break; }
                TreeNode pl = ptr.left, pr = ptr.right;
                while (pl.right != null && pr.left != null) { pl = pl.right; pr = pr.left; }
                if (pl.right == null)
                {
                    pl.right = ptr.right;
                    if (lchid) fa.left = ptr.left; else fa.right = ptr.left;
                }
                else
                {
                    pr.left = ptr.left;
                    if (lchid) fa.left = ptr.right; else fa.right = ptr.right;
                }
                break;
            }

            return dummy.left;
        }
    }
}
