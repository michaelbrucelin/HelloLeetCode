using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0783
{
    public class Solution0783 : Interface0783
    {
        /// <summary>
        /// DFS
        /// 二叉搜索树的中序序列时升序排列的
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinDiffInBST(TreeNode root)
        {
            List<int> tree = new List<int>();
            dfs(root);

            int result = tree[1] - tree[0];
            for (int i = 2; i < tree.Count; i++) result = Math.Min(result, tree[i] - tree[i - 1]);

            return result;

            void dfs(TreeNode node)
            {
                if (node == null) return;
                dfs(node.left);
                tree.Add(node.val);
                dfs(node.right);
            }
        }

        /// <summary>
        /// 同MinDiffInBST()，只是没有保存整个的中序遍历结果
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinDiffInBST2(TreeNode root)
        {
            int result = int.MaxValue, pre = -1;
            dfs(root);

            return result;

            void dfs(TreeNode node)
            {
                if (node == null) return;
                dfs(node.left);
                if (pre != -1) result = Math.Min(result, node.val - pre);
                pre = node.val;
                dfs(node.right);
            }
        }
    }
}
