using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0043
{
    public class Solution0043
    {
    }

    /// <summary>
    /// 队列
    /// </summary>
    public class CBTInserter
    {
        public CBTInserter(TreeNode root)
        {
            this.root = root;
            queue = new Queue<TreeNode>();
            Queue<TreeNode> _queue = new Queue<TreeNode>();
            _queue.Enqueue(root);
            TreeNode node;
            while (_queue.Count > 0)
            {
                node = _queue.Dequeue();
                queue.Enqueue(node);
                if (node.left != null) _queue.Enqueue(node.left);
                if (node.right != null) _queue.Enqueue(node.right);
            }

            ptr = queue.Dequeue();
            while (ptr.left != null && ptr.right != null) ptr = queue.Dequeue();
        }

        private Queue<TreeNode> queue;
        private TreeNode root;
        private TreeNode ptr;

        public int Insert(int v)
        {
            if (ptr.left != null && ptr.right != null) ptr = queue.Dequeue();
            TreeNode node = new TreeNode(v);
            queue.Enqueue(node);
            if (ptr.left == null) ptr.left = node; else ptr.right = node;

            return ptr.val;
        }

        public TreeNode Get_root()
        {
            return root;
        }
    }
}
