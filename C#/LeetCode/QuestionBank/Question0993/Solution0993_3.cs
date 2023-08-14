using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0993
{
    public class Solution0993_3 : Interface0993
    {
        /// <summary>
        /// BFS
        /// BFS每次可以获得一层的元素，然后检查是否同时包含x和y即可
        /// </summary>
        /// <param name="root"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsCousins(TreeNode root, int x, int y)
        {
            if (x == y || x == root.val || y == root.val) return false;

            Dictionary<int, TreeNode> dic = new Dictionary<int, TreeNode>();
            Queue<TreeNode> queue = new Queue<TreeNode>(); queue.Enqueue(root);
            int cnt; TreeNode node;
            while ((cnt = queue.Count) > 0)
            {
                dic.Clear();
                for (int i = 0; i < cnt; i++)
                {
                    node = queue.Dequeue();
                    if (node.left != null) { queue.Enqueue(node.left); dic.Add(node.left.val, node); }
                    if (node.right != null) { queue.Enqueue(node.right); dic.Add(node.right.val, node); }
                }
                if (dic.ContainsKey(x) && dic.ContainsKey(y)) return dic[x] != dic[y];
                if (dic.ContainsKey(x) && !dic.ContainsKey(y)) return false;
                if (!dic.ContainsKey(x) && dic.ContainsKey(y)) return false;
            }

            return false;
        }
    }
}
