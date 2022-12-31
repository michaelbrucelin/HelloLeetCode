using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0100
{
    public class Solution0100 : Interface0100
    {
        /// <summary>
        /// 将树序列化为Value:{Left:XXX;Right:YYY}的形式，然后比较字符串
        /// 缺点，需要将两棵树完整的遍历一次后，才可以比较
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            string str_p = SerializeTree(p);
            string str_q = SerializeTree(q);

            return str_p == str_q;
        }

        private string SerializeTree(TreeNode node)
        {
            if (node == null) return "null";

            return $"{node.val}:{{{SerializeTree(node.left)};{SerializeTree(node.right)}}}";
        }
    }
}
