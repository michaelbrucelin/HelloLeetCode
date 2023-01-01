using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0101
{
    public class Solution0101 : Interface0101
    {
        /// <summary>
        /// 将树序列化为Value:{Left:XXX;Right:YYY}的形式，然后比较字符串
        /// 缺点，需要将两棵树完整的遍历一次后，才可以比较
        /// 
        /// 本质上就是同时遍历根的左子树与根的右子树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            string str_left = SerializeTree(root.left, true);
            string str_right = SerializeTree(root.right, false);

            return str_left == str_right;
        }

        /// <summary>
        /// 将树序列化为字符串
        /// </summary>
        /// <param name="node"></param>
        /// <param name="type">true: 根-左-右；false: 根-右-左</param>
        /// <returns></returns>
        private string SerializeTree(TreeNode node, bool type)
        {
            if (node == null) return "null";

            if (type)
                return $"{node.val}:{{{SerializeTree(node.left, type)};{SerializeTree(node.right, type)}}}";
            else
                return $"{node.val}:{{{SerializeTree(node.right, type)};{SerializeTree(node.left, type)}}}";
        }
    }
}
