using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0116
{
    public class Solution0116_2 : Interface0116
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
            if (root == null || root.left == null) return root;

            Node ptr_down = root, ptr_right;
            while (ptr_down.left != null)
            {
                ptr_right = ptr_down;
                while (true)
                {
                    ptr_right.left.next = ptr_right.right;
                    if (ptr_right.next != null)
                    {
                        ptr_right.right.next = ptr_right.next.left;
                        ptr_right = ptr_right.next;
                    }
                    else
                    {
                        break;
                    }
                }

                ptr_down = ptr_down.left;
            }

            return root;
        }
    }
}
