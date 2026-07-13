using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0156
{
    public class Solution0156
    {
    }

    /// <summary>
    /// 模拟
    /// </summary>
    public class Codec : Interface0156
    {
        public string serialize(TreeNode root)
        {
            if (root == null) return "[]";

            StringBuilder buffer = new StringBuilder("[");
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            TreeNode node;
            while (queue.Count > 0)
            {
                if ((node = queue.Dequeue()) != null)
                {
                    buffer.Append($"{node.val},");
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
                else
                {
                    buffer.Append("null,");
                }
            }
            buffer.Length--;
            while (buffer[^1] == 'l') buffer.Length -= 5;
            buffer.Append("]");

            return buffer.ToString();
        }

        public TreeNode deserialize(string data)
        {
            if (data.Length == 2) return null;

            string[] vals = data[1..^1].Split([',']);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode root = new TreeNode(int.Parse(vals[0]));
            TreeNode node = root;
            queue.Enqueue(root);
            string val; int len = vals.Length; bool left = false;
            for (int i = 1; i < len; i++)
            {
                val = vals[i];
                left = !left;
                if (left) node = queue.Dequeue();
                if (val != "null")
                {
                    TreeNode _node = new TreeNode(int.Parse(val));
                    if (left) node.left = _node; else node.right = _node;
                    queue.Enqueue(_node);
                }
            }

            return root;
        }
    }
}
