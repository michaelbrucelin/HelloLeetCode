using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0589
{
    public class Solution0589_2 : Interface0589
    {
        /// <summary>
        /// 递归
        /// DFS，有返回值
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Preorder(Node root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;

            result.Add(root.val);
            for (int i = 0; i < root.children.Count; i++)
                result.AddRange(Preorder(root.children[i]));

            return result;
        }
    }
}
