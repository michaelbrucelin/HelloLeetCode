using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1145
{
    public class Solution1145 : Interface1145
    {
        /// <summary>
        /// 分析
        /// 1. 首先，最优解一定在x的邻节点（父节点，左右子节点）当中
        /// 2. 统计x左子树与右子树的节点数，再结合树的总节点数与第一条结论，即可获得结果
        /// 
        /// DFS
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

        /// <summary>
        /// 同BtreeGameWinningMove()，稍作优化
        /// </summary>
        /// <param name="root"></param>
        /// <param name="n"></param>
        /// <param name="x"></param>
        /// <returns></returns>
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
            TreeNode _result = FindNode(root.left, x);
            if (_result != null) return _result;
            return FindNode(root.right, x);
        }

        private int CountNode(TreeNode root)
        {
            if (root == null) return 0;
            return CountNode(root.left) + CountNode(root.right) + 1;
        }

        /// <summary>
        /// 分析
        /// 1. 首先，最优解一定在x的邻节点（父节点，左右子节点）当中
        /// 2. 统计x左子树与右子树的节点数，再结合树的总节点数与第一条结论，即可获得结果
        /// 
        /// 上面的逻辑没错，但是树的节点的值不是按1,2,3...的顺序来的，所以此解法是错误的
        /// </summary>
        /// <param name="root"></param>
        /// <param name="n"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool BtreeGameWinningMove_Error(TreeNode root, int n, int x)
        {
            int lcnt = 0, rcnt = 0;
            Queue<int> queue = new Queue<int>(); int cnt;
            queue.Enqueue(x << 1); while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    int val = queue.Dequeue();
                    if (val <= n) { lcnt++; queue.Enqueue(val << 1); queue.Enqueue((val << 1) + 1); }
                }
            }
            queue.Enqueue((x << 1) + 1); while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    int val = queue.Dequeue();
                    if (val <= n) { rcnt++; queue.Enqueue(val << 1); queue.Enqueue((val << 1) + 1); }
                }
            }

            int half = n >> 1;
            if (lcnt > half || rcnt > half || (lcnt + rcnt + 1) <= half) return true; else return false;
        }
    }
}
