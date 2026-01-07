using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1339
{
    public class Solution1339 : Interface1339
    {
        /// <summary>
        /// 两轮DFS
        /// DFS，更新整棵树，树的节点中记录以当前节点为根的子树的和
        /// DFS，寻找最大值
        /// 
        /// 优化，x+y=s，xy的最大值是s*s/4，即x与y越接近，积越大，可以利用这个剪枝，这里先不优化
        /// 这里就不复制一颗新树了，直接原地操作
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxProduct(TreeNode root)
        {
            update(root);
            const int MOD = (int)1e9 + 7;
            long result = 0, sum = root.val;
            find(root);
            return (int)(result % MOD);

            void find(TreeNode node)
            {
                if (node.left != null)
                {
                    result = Math.Max(result, 1L * node.left.val * (sum - node.left.val));
                    find(node.left);
                }
                if (node.right != null)
                {
                    result = Math.Max(result, 1L * node.right.val * (sum - node.right.val));
                    find(node.right);
                }
            }

            static int update(TreeNode node)
            {
                if (node == null) return 0;
                node.val += update(node.left);
                node.val += update(node.right);
                return node.val;
            }
        }

        /// <summary>
        /// 逻辑同MaxProduct()，不改变原树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxProduct2(TreeNode root)
        {
            int sum = GetSum(root);
            int half = (sum + 1) >> 1;
            const int MOD = (int)1e9 + 7;
            long result = 0;
            GetProduct(root);
            return (int)(result % MOD);

            int GetProduct(TreeNode node)
            {
                if (node == null) return 0;
                int subsum = GetProduct(node.left) + GetProduct(node.right) + node.val;
                result = Math.Max(result, 1L * subsum * (sum - subsum));
                return subsum;
            }

            static int GetSum(TreeNode node)
            {
                if (node == null) return 0;
                return GetSum(node.left) + GetSum(node.right) + node.val;
            }
        }
    }
}
