using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetCode.QuestionBank.Question0590
{
    public class Solution0590_2 : Interface0590
    {
        /// <summary>
        /// 迭代，染色法
        /// 每个节点第一次入栈的时候是红色，第二次入栈是绿色，弹栈的时候如果是红色需要再次入栈，如果是绿色即输出
        /// 1. 将一个节点node入栈（红）
        /// 2. 倒叙将node的所有孩子入栈（红），直到第一个孩子
        ///     倒叙将第一个孩子的所有孩子入栈（红）
        ///     ... ...
        ///     直到第一个孩子没有孩子
        /// 3. 弹栈
        ///     如果节点为绿色，输出结果，回到3
        ///     如果节点为红色，将节点重新入栈（绿色），回到2
        /// 4. 栈空程序结束
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Postorder(Node root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;

            Stack<(Node node, bool done)> stack = new Stack<(Node node, bool done)>();
            List<Node> list = new List<Node>() { root };
            int id = list.Count - 1; Node ptr = list[id];
            while (ptr != null)
            {
                //stack.Push((ptr, false));
                //while(ptr.children!=null && ptr.children.Count > 0)
                //{
                //    list 
                //}
            }

            return result;
        }
    }
}
