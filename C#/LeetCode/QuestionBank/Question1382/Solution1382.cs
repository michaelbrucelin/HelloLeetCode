using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1382
{
    public class Solution1382 : Interface1382
    {
        /// <summary>
        /// 中序遍历 + 构造
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode BalanceBST(TreeNode root)
        {
            List<TreeNode> list = new List<TreeNode>();
            dfs(root);

            return build(0, list.Count - 1);

            void dfs(TreeNode node)
            {
                if (node == null) return;
                dfs(node.left);
                list.Add(node);
                dfs(node.right);
            }

            TreeNode build(int left, int right)
            {
                if (left > right) return null;

                int mid = left + ((right - left) >> 1);
                list[mid].left = build(left, mid - 1);
                list[mid].right = build(mid + 1, right);

                return list[mid];
            }
        }
    }
}
