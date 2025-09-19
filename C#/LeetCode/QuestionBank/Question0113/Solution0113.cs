using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0113
{
    public class Solution0113 : Interface0113
    {
        /// <summary>
        /// DFS
        /// 无返回值
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;
            dfs(root, [], 0);
            return result;

            void dfs(TreeNode node, List<int> list, int sum)
            {
                sum += node.val;
                list.Add(node.val);
                if (node.left == null && node.right == null)
                {
                    if (sum == targetSum) result.Add(list);
                    return;
                }

                switch (node.left, node.right)
                {
                    case (_, null):
                        dfs(node.left, list, sum);
                        break;
                    case (null, _):
                        dfs(node.right, list, sum);
                        break;
                    default:
                        dfs(node.left, [.. list], sum);
                        dfs(node.right, list, sum);
                        break;
                }
            }
        }
    }
}
