using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0102
{
    public class Solution0102_3 : Interface0102
    {
        /// <summary>
        /// 迭代
        /// 前序遍历的迭代，构造层序遍历的结果
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
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            Stack<(int level, TreeNode node)> stack = new Stack<(int, TreeNode)>();
            int level = 0; TreeNode ptr = root;
            while (ptr != null)
            {
                if (level == result.Count) result.Add(new List<int>());
                result[level].Add(ptr.val);
                if (ptr.left != null)
                {
                    if (ptr.right != null) stack.Push((level + 1, ptr.right));
                    ptr = ptr.left;
                    level++;
                }
                else
                {
                    if (ptr.right != null) { ptr = ptr.right; level++; }
                    else if (stack.Count > 0) { var item = stack.Pop(); ptr = item.node; level = item.level; }
                    else break;
                }
            }

            return result;
        }
    }
}
