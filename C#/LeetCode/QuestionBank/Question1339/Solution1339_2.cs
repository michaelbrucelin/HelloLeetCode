using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1339
{
    public class Solution1339_2 : Interface1339
    {
        /// <summary>
        /// DFS
        /// 逻辑同Solution1339，做了如下几点优化
        /// 1. 不更改原树
        /// 2. 这里是自顶向下DFS，所以如果一个子树的和小于整棵树和的一半，就没必要继续了
        ///     x+y=s，xy的最大值是s*s/4，即x与y越接近，积越大，可以利用这个剪枝
        /// 
        /// 提交反而变慢了，大概率是因为测试用例的节点数不够多，Hash导致的变慢
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxProduct(TreeNode root)
        {
            Dictionary<TreeNode, int> sums = new Dictionary<TreeNode, int>();
            GetSum(root);
            int sum = sums[root];
            int half = sum >> 1;
            const int MOD = (int)1e9 + 7;
            long result = 0;
            GetProduct(root);
            return (int)(result % MOD);

            void GetProduct(TreeNode node)
            {
                if (node == null) return;
                result = Math.Max(result, 1L * sums[node] * (sum - sums[node]));
                if (sums[node] < half) return;
                GetProduct(node.left);
                GetProduct(node.right);
            }

            void GetSum(TreeNode node)
            {
                if (node == null) return;
                GetSum(node.left);
                GetSum(node.right);
                sums.Add(node, (node.left != null ? sums[node.left] : 0) + (node.right != null ? sums[node.right] : 0) + node.val);
            }
        }
    }
}
