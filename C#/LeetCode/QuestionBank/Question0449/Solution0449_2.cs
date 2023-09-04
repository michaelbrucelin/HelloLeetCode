using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0449
{
    public class Solution0449_2
    {
    }

    public class Codec_2 : Interface0449
    {
        public TreeNode deserialize(string data)
        {
            if (data.Length == 0) return null;

            int r = data.IndexOf(','), l = r + 1, len = data.Length;
            TreeNode root = new TreeNode(int.Parse(data.Substring(0, r)));
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (l < len && queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();

                if ((r = data.IndexOf(',', l)) > l)
                {
                    TreeNode left = new TreeNode(int.Parse(data.Substring(l, r - l)));
                    node.left = left;
                    queue.Enqueue(left);
                }
                l = r + 1;

                if ((r = data.IndexOf(',', l)) > l)
                {
                    TreeNode right = new TreeNode(int.Parse(data.Substring(l, r - l)));
                    node.right = right;
                    queue.Enqueue(right);
                }
                l = r + 1;
            }

            return root;
        }

        /// <summary>
        /// BFS
        /// 通用的二叉树序列化，与是不是二叉搜索树没有关系
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public string serialize(TreeNode root)
        {
            if (root == null) return "";

            StringBuilder result = new StringBuilder();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node == null)
                {
                    result.Append(',');
                }
                else
                {
                    result.Append(node.val); result.Append(',');
                    queue.Enqueue(node.left); queue.Enqueue(node.right);
                }
            }

            return result.ToString();
        }
    }
}
