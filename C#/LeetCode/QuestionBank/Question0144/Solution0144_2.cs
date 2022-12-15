using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0144
{
    public class Solution0144_2 : Interface0144
    {
        /// <summary>
        /// 迭代
        /// 1. 将指针指向根节点
        /// 2. 输出指针
        /// 3. 判断指针的孩子情况
        ///     3.1. 有左有右，右孩子入栈，指针指向左孩子
        ///     3.2. 有左无右，指针指向左孩子
        ///     3.2. 无左有右，指针指向右孩子
        ///     3.4. 无左无右，指针指向栈顶（弹栈）
        /// 4. 回到步骤2
        /// 5. 直至指针无左无右且栈空，遍历结束
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode ptr = root;
            while (ptr != null)
            {
                result.Add(ptr.val);
                if (ptr.left != null)
                {
                    if (ptr.right != null) stack.Push(ptr.right);
                    ptr = ptr.left;
                }
                else
                {
                    if (ptr.right != null) ptr = ptr.right;
                    else if (stack.Count > 0) ptr = stack.Pop();
                    else break;
                }
            }

            return result;
        }
    }
}
