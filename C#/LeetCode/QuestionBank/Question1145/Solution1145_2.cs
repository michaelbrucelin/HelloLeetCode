using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1145
{
    public class Solution1145_2 : Interface1145
    {
        /// <summary>
        /// 同Solution1145，BFS
        /// </summary>
        /// <param name="root"></param>
        /// <param name="n"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool BtreeGameWinningMove(TreeNode root, int n, int x)
        {
            TreeNode nodex = FindNode(root, x);
            if (nodex == null) return true;
            int lcnt = CountNode(nodex.left), rcnt = CountNode(nodex.right);

            int half = n >> 1;
            if (lcnt > half || rcnt > half || (lcnt + rcnt + 1) <= half) return true; else return false;
        }

        public bool BtreeGameWinningMove2(TreeNode root, int n, int x)
        {
            TreeNode nodex = FindNode(root, x);
            if (nodex == null) return true;

            int half = n >> 1;
            int lcnt = CountNode(nodex.left);
            if (lcnt > half) return true;

            int rcnt = CountNode(nodex.right);
            if (rcnt > half) return true;

            return (lcnt + rcnt + 1) <= half;
        }

        private TreeNode FindNode(TreeNode root, int x)
        {
            if (root == null) return null;
            if (root.val == x) return root;

            Queue<TreeNode> queue = new Queue<TreeNode>(); queue.Enqueue(root);
            int cnt; while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (node.val == x) return node;
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }

            return null;
        }

        private int CountNode(TreeNode root)
        {
            if (root == null) return 0;

            int result = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>(); queue.Enqueue(root);
            int cnt; while ((cnt = queue.Count) > 0)
            {
                result += cnt;
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }

            return result;
        }
    }
}
