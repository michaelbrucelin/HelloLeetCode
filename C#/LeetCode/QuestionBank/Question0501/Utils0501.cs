using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0501
{
    public class Utils0501
    {
        public static TreeNode Str2TreeNode(string raw)
        {
            int?[] vals = raw[1..^1].Split(',').Select(s => (int?)(s == "null" ? null : int.Parse(s, CultureInfo.InvariantCulture.NumberFormat))).ToArray();
            if (vals.Length == 0 || vals[0] == null) return null;

            TreeNode root = new TreeNode((int)vals[0]);
            Queue<TreeNode> queue = new Queue<TreeNode>(); queue.Enqueue(root);
            int ptr = 0, len = vals.Length;
            while (queue.Count > 0 && ptr < len)
            {
                TreeNode node = queue.Dequeue();

                if (++ptr < len && vals[ptr] != null)
                {
                    TreeNode left = new TreeNode((int)vals[ptr]);
                    node.left = left; queue.Enqueue(left);
                }
                if (++ptr < len && vals[ptr] != null)
                {
                    TreeNode right = new TreeNode((int)vals[ptr]);
                    node.right = right; queue.Enqueue(right);
                }
            }

            return root;
        }
    }
}
