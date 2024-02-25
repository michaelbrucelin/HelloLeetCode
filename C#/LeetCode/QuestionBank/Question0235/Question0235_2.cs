using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0235
{
    public class Question0235_2 : Interface0235
    {
        /// <summary>
        /// 迭代
        /// 逻辑同Solution0235，只是将递归改为了显示的迭代
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            TreeNode item;
            while (stack.Count > 0)
            {
                item = stack.Pop();
                if (p == item || q == item) return item;
                if (p.val == q.val) return p;
                // if ((p.val - item.val) * (q.val - item.val) < 0) 担心会溢出
                if ((p.val < item.val && q.val > item.val) || (p.val > item.val && q.val < item.val)) return item;
                stack.Push((p.val < item.val && q.val < item.val) ? item.left : item.right);
            }

            throw new Exception("logic error.");
        }

        /// <summary>
        /// 迭代
        /// 与LowestCommonAncestor()逻辑一样，但是思路不一样，LowestCommonAncestor()是递归一比一过来的，这里是纯粹的迭代
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public TreeNode LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode ptr = root;
            while (ptr != null)
            {
                if (p == ptr || q == ptr) return ptr;
                if (p.val == q.val) return p;
                // if ((p.val - item.val) * (q.val - item.val) < 0) 担心会溢出
                if ((p.val < ptr.val && q.val > ptr.val) || (p.val > ptr.val && q.val < ptr.val)) return ptr;
                ptr = (p.val < ptr.val && q.val < ptr.val) ? ptr.left : ptr.right;
            }

            throw new Exception("logic error.");
        }
    }
}
