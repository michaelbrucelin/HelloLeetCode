using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0257
{
    public class Solution0257_2 : Interface0257
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            List<string> paths = new List<string>();
            if (root == null) return paths;

            Queue<TreeNode> queue1 = new Queue<TreeNode>(); queue1.Enqueue(root);
            Queue<string> queue2 = new Queue<string>(); queue2.Enqueue(root.val.ToString());
            int cnt; while ((cnt = queue1.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = queue1.Dequeue();
                    string path = queue2.Dequeue();
                    if (node.left == null && node.right == null)
                    {
                        paths.Add(path);
                    }
                    else
                    {
                        if (node.left != null) { queue1.Enqueue(node.left); queue2.Enqueue($"{path}->{node.left.val}"); }
                        if (node.right != null) { queue1.Enqueue(node.right); queue2.Enqueue($"{path}->{node.right.val}"); }
                    }
                }
            }

            return paths;
        }
    }
}
