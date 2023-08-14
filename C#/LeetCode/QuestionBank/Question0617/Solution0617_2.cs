using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0617
{
    public class Solution0617_2 : Interface0617
    {
        /// <summary>
        /// BFS
        /// 明确的逐层合并，很明确当前合并到第几层
        /// </summary>
        /// <param name="root1"></param>
        /// <param name="root2"></param>
        /// <returns></returns>
        public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null) return null;
            if (root1 == null) return root2;
            if (root2 == null) return root1;

            TreeNode root = new TreeNode(root1.val + root2.val);
            Queue<TreeNode> queue0 = new Queue<TreeNode>(); queue0.Enqueue(root);
            Queue<TreeNode> queue1 = new Queue<TreeNode>(); queue1.Enqueue(root1);
            Queue<TreeNode> queue2 = new Queue<TreeNode>(); queue2.Enqueue(root2);

            int cnt; TreeNode n0, n1, n2;
            while ((cnt = queue0.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    n0 = queue0.Dequeue(); n1 = queue1.Dequeue(); n2 = queue2.Dequeue();
                    if (n1.left != null || n2.left != null)
                    {
                        if (n1.left == null) n0.left = n2.left;
                        else if (n2.left == null) n0.left = n1.left;
                        else  // if (n1.left != null && n2.left != null)
                        {
                            TreeNode node = new TreeNode(n1.left.val + n2.left.val);
                            n0.left = node;
                            queue0.Enqueue(node); queue1.Enqueue(n1.left); queue2.Enqueue(n2.left);
                        }
                    }
                    if (n1.right != null || n2.right != null)
                    {
                        if (n1.right == null) n0.right = n2.right;
                        else if (n2.right == null) n0.right = n1.right;
                        else  // if (n1.right != null && n2.right != null)
                        {
                            TreeNode node = new TreeNode(n1.right.val + n2.right.val);
                            n0.right = node;
                            queue0.Enqueue(node); queue1.Enqueue(n1.right); queue2.Enqueue(n2.right);
                        }
                    }
                }
            }

            return root;
        }

        /// <summary>
        /// BFS
        /// 逐层合并，不明确当前合并到第几层
        /// </summary>
        /// <param name="root1"></param>
        /// <param name="root2"></param>
        /// <returns></returns>
        public TreeNode MergeTrees2(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null) return null;
            if (root1 == null) return root2;
            if (root2 == null) return root1;

            TreeNode root = new TreeNode(root1.val + root2.val);
            Queue<TreeNode> queue0 = new Queue<TreeNode>(); queue0.Enqueue(root);
            Queue<TreeNode> queue1 = new Queue<TreeNode>(); queue1.Enqueue(root1);
            Queue<TreeNode> queue2 = new Queue<TreeNode>(); queue2.Enqueue(root2);

            TreeNode n0, n1, n2;
            while (queue0.Count > 0)
            {
                n0 = queue0.Dequeue(); n1 = queue1.Dequeue(); n2 = queue2.Dequeue();
                if (n1.left != null || n2.left != null)
                {
                    if (n1.left == null) n0.left = n2.left;
                    else if (n2.left == null) n0.left = n1.left;
                    else  // if (n1.left != null && n2.left != null)
                    {
                        TreeNode node = new TreeNode(n1.left.val + n2.left.val);
                        n0.left = node;
                        queue0.Enqueue(node); queue1.Enqueue(n1.left); queue2.Enqueue(n2.left);
                    }
                }
                if (n1.right != null || n2.right != null)
                {
                    if (n1.right == null) n0.right = n2.right;
                    else if (n2.right == null) n0.right = n1.right;
                    else  // if (n1.right != null && n2.right != null)
                    {
                        TreeNode node = new TreeNode(n1.right.val + n2.right.val);
                        n0.right = node;
                        queue0.Enqueue(node); queue1.Enqueue(n1.right); queue2.Enqueue(n2.right);
                    }
                }
            }

            return root;
        }
    }
}
