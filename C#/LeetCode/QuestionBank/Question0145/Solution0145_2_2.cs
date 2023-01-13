using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0145
{
    public class Solution0145_2_2 : Interface0145
    {
        /// <summary>
        /// 迭代
        /// 本质上就是采用“根->右->左”的伪前序遍历方式进行前序遍历，只不过操作节点改为入栈，最后整体弹栈（反序）
        /// 1. 将指针指向根节点
        /// 2. 指针入栈1
        /// 3. 判断指针的孩子情况
        ///     3.1. 有右有左，左孩子入栈2，指针指向右孩子
        ///     3.2. 有右无左，指针指向右孩子
        ///     3.2. 无右有左，指针指向左孩子
        ///     3.4. 无右无左，指针指向栈2的栈顶（弹栈）
        /// 4. 回到步骤2
        /// 5. 直至指针无左无右且栈2为空栈，将栈1中的元素一次弹栈并输出
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PostorderTraversal(TreeNode root)
        {
            Stack<int> result = new Stack<int>();
            if (root == null) return new List<int>();

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode ptr = root;
            while (ptr != null)
            {
                result.Push(ptr.val);
                if (ptr.right != null)
                {
                    if (ptr.left != null) stack.Push(ptr.left);
                    ptr = ptr.right;
                }
                else
                {
                    if (ptr.left != null) ptr = ptr.left;
                    else if (stack.Count > 0) ptr = stack.Pop();
                    else break;
                }
            }

            return result.ToList();
        }
    }
}
