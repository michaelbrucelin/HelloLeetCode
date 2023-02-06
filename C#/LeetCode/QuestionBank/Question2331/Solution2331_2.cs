using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2331
{
    public class Solution2331_2 : Interface2331
    {
        /// <summary>
        /// 迭代
        /// 1. 指针只想树的根节点
        /// 2. 如果指针有左孩子
        ///     指针入栈，右孩子（有左必有右）入栈，指针指向左孩子
        ///     继续步骤2，直至指针没有左孩子
        /// 3. 将指针的值赋值给临时变量1（必是值，没有左孩子）
        /// 4. 弹栈到临时变量2
        ///     如果临时变量2有左孩子，临时变量1入栈，指针指向临时变量2，回到步骤2
        ///     如果临时变量2没有左孩子，弹栈到临时变量3，3个临时变量计算结果赋值给临时变量1，继续步骤4
        /// 
        /// 没完成，本想用迭代再实现一次，但是写起来闹心，不写了
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool EvaluateTree(TreeNode root)
        {
            if (root.left == null) return root.val == 1;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode ptr = root, temp1 = null, temp2;  //, temp3;
            while (ptr.left != null || stack.Count > 0)
            {
                Step2:
                while (ptr.left != null)
                {
                    stack.Push(ptr); stack.Push(ptr.right); ptr = ptr.left;
                }
                temp1 = ptr;
                if (stack.Count == 0) break;
                temp2 = stack.Pop();
                if (temp2.left != null)
                {
                    stack.Push(temp1); ptr = temp2;
                    goto Step2;
                }
                else
                {

                }
            }

            return temp1.val == 1;
        }
    }
}
