using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0236
{
    public class Utils0236
    {
        public TreeNode BuildTree(string raw)
        {
            string[] vals = raw[1..^1].Split(',');
            TreeNode root = new TreeNode(int.Parse(vals[0]));
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int ptr = 1, len = vals.Length; TreeNode node;
            while (ptr < len)
            {
                if ((node = queue.Dequeue()) == null)
                {
                    ptr += 2; continue;
                }
                if (ptr < len)
                {
                    if (vals[ptr] != "null")
                    {
                        TreeNode left = new TreeNode(int.Parse(vals[ptr]));
                        node.left = left;
                        queue.Enqueue(left);
                    }
                    else
                    {
                        queue.Enqueue(null);
                    }
                }
                ptr++;
                if (ptr < len)
                {
                    if (vals[ptr] != "null")
                    {
                        TreeNode right = new TreeNode(int.Parse(vals[ptr]));
                        node.right = right;
                        queue.Enqueue(right);
                    }
                    else
                    {
                        queue.Enqueue(null);
                    }
                }
                ptr++;
            }

            return root;
        }

        public TreeNode FindTreeNode(TreeNode root, int val)
        {
            if(root.val==val) return root;

            return null;
        }
    }
}
