using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0589
{
    public class Solution0589 : Interface0589
    {
        /// <summary>
        /// 递归
        /// DFS，无返回值
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Preorder(Node root)
        {
            List<int> result = new List<int>();
            rec(root, result);

            return result;
        }

        private void rec(Node node, List<int> list)
        {
            if (node == null) return;
            list.Add(node.val);
            for (int i = 0; i < node.children.Count; i++)
                rec(node.children[i], list);
        }
    }
}
