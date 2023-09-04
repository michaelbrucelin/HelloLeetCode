using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0449
{
    public class Solution0449
    {
    }

    public class Codec : Interface0449
    {
        public TreeNode deserialize(string data)
        {
            if (data[0] == ',') return null;

            int r = 0;
            return dfs_deserialize(data, ref r);
        }

        private TreeNode dfs_deserialize(string data, ref int start)
        {
            if (start >= data.Length) return null;
            if (data[start] == ',') { start++; return null; }

            int r = data.IndexOf(',', start);
            int val = int.Parse(data.Substring(start, r - start));
            TreeNode node = new TreeNode(val);
            start = r + 1;
            node.left = dfs_deserialize(data, ref start);
            node.right = dfs_deserialize(data, ref start);

            return node;
        }

        /// <summary>
        /// DFS
        /// 前序遍历
        /// 通用的二叉树序列化，与是不是二叉搜索树没有关系
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public string serialize(TreeNode root)
        {
            StringBuilder result = new StringBuilder();
            dfs_serialize(root, result);

            return result.ToString();
        }

        private void dfs_serialize(TreeNode node, StringBuilder sb)
        {
            if (node == null)
            {
                sb.Append(',');
            }
            else
            {
                sb.Append(node.val); sb.Append(',');
                dfs_serialize(node.left, sb);
                dfs_serialize(node.right, sb);
            }
        }
    }
}
