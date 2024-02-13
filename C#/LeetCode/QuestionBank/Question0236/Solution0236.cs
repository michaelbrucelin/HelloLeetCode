using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0236
{
    public class Solution0236 : Interface0236
    {
        /// <summary>
        /// DFS
        /// 1. dfs找出root -> node -> node -> ... -> p
        /// 2. dfs找出root -> node -> node -> ... -> q
        /// 3. 在这两个list中通过二分查找可以找到p q的最近公共祖先
        /// 
        /// 逻辑没问题，提交TLE，参考测试用例04
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            List<TreeNode> ppath = dfs(root, p, new List<TreeNode>());
            List<TreeNode> qpath = dfs(root, q, new List<TreeNode>());

            int result = -1, left = 0, right = Math.Min(ppath.Count, qpath.Count) - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (ppath[mid] == qpath[mid])
                {
                    result = mid; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return ppath[result];
        }

        private List<TreeNode> dfs(TreeNode root, TreeNode node, List<TreeNode> path)
        {
            if (root == null) return path;
            path.Add(root);

            if (root == node) return path;
            var left = dfs(root.left, node, new List<TreeNode>(path));
            if (left[^1] == node) return left;
            return dfs(root.right, node, new List<TreeNode>(path));
        }
    }
}
