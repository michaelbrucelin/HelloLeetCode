using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0117
{
    public class Solution0117_2 : Interface0117
    {
        /// <summary>
        /// 类BFS
        /// 假设前n层已经处理完事，现在需要处理第n+1层，
        ///     那么只要知道第n层的一个节点，就可以一次找到第n层的全部节点，因为有next指针
        ///                                  就可以找到第n+1层的第一个节点
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node Connect(Node root)
        {
            if (root == null) return root;

            Node ptr_down = root, ptr_right1, ptr_right2;
            while ((ptr_right1 = ptr_down) != null)
            {
                ptr_right2 = null;
                while (ptr_right1 != null)  // 找下一层第一个节点
                {
                    if (ptr_right1.left != null) { ptr_down = ptr_right2 = ptr_right1.left; break; }
                    if (ptr_right1.right != null) { ptr_down = ptr_right2 = ptr_right1.right; break; }
                    ptr_right1 = ptr_right1.next;
                }
                if (ptr_right2 == null) break;

                if (ptr_right2 == ptr_right1.left)
                {
                    if (ptr_right1.right != null) { ptr_right2.next = ptr_right1.right; ptr_right2 = ptr_right2.next; }
                }
                while ((ptr_right1 = ptr_right1.next) != null)
                {
                    if (ptr_right1.left != null) { ptr_right2.next = ptr_right1.left; ptr_right2 = ptr_right2.next; }
                    if (ptr_right1.right != null) { ptr_right2.next = ptr_right1.right; ptr_right2 = ptr_right2.next; }
                }
            }

            return root;
        }
    }
}
