using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0145
{
    public class Solution0145_2 : Interface0145
    {
        /// <summary>
        /// 迭代
        /// 后续遍历除了一个指针指向遍历的节点外，还需要另外一个指针用来记录上一次处理的节点，这里称作prev
        /// 1. 指针指向根节点，prev指向null
        /// 2. 判断指针的孩子情况
        ///     2.1. 有左有右
        ///         如果右孩子是prev，输出指针，prev指向指针，指针指向栈顶（弹栈）
        ///         如果右孩子不是prev，指针入栈，右孩子入栈，指针指向左孩子
        ///         回到步骤2
        ///     2.2. 有右无左
        ///         如果右孩子是prev，输出指针，prev指向指针，指针指向栈顶（弹栈）
        ///         如果右孩子不是prev，指针入栈，指针指向右孩子
        ///         回到步骤2
        ///     2.3. 有左无右
        ///         如果左孩子是prev，输出指针，prev指向指针，指针指向栈顶（弹栈）
        ///         如果左孩子不是prev，指针入栈，指针指向左孩子
        ///         回到步骤2
        ///     2.4. 无左无右
        ///         输出指针，prev指向指针，指针指向栈顶（弹栈）
        ///         回到步骤2
        /// 3. 直至栈空
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode ptr = root, prev = null;
            while (ptr != null)
            {
                if (ptr.right != null)
                {
                    if (ptr.right == prev)
                    {
                        result.Add(ptr.val); prev = ptr;
                        if (stack.Count > 0) ptr = stack.Pop(); else break;
                    }
                    else
                    {
                        stack.Push(ptr);
                        if (ptr.left != null) { stack.Push(ptr.right); ptr = ptr.left; } else ptr = ptr.right;
                    }
                }
                else if (ptr.left != null)
                {
                    if (ptr.left == prev)
                    {
                        result.Add(ptr.val); prev = ptr;
                        if (stack.Count > 0) ptr = stack.Pop(); else break;
                    }
                    else
                    {
                        stack.Push(ptr); ptr = ptr.left;
                    }
                }
                else
                {
                    result.Add(ptr.val); prev = ptr;
                    if (stack.Count > 0) ptr = stack.Pop(); else break;
                }
            }

            return result;
        }
    }
}
