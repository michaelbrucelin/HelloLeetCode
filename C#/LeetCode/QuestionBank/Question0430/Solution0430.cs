using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0430
{
    public class Solution0430 : Interface0430
    {
        /// <summary>
        /// 递归
        /// 每次递归，返回这一层的尾节点
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node Flatten(Node head)
        {
            if (head == null) return head;
            return head;

            static Node rec(Node node)
            {
                throw new NotImplementedException();
            }
        }
    }
}
