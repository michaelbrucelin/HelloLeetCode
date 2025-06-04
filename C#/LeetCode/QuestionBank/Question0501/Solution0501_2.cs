using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0501
{
    public class Solution0501_2 : Interface0501
    {
        /// <summary>
        /// DFS，中序遍历
        /// 二叉搜索树的中序遍历是升序数组
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int[] FindMode(TreeNode root)
        {
            int max = 0, cnt = -1, prev = int.MinValue;
            List<int> result = new List<int>();
            dfs(root, ref max, ref cnt, ref prev, result);
            if (cnt > max)
            {
                result.Clear(); result.Add(prev); max = cnt;
            }
            else if (cnt == max)
            {
                result.Add(prev);
            }

            return result.ToArray();
        }

        private void dfs(TreeNode node, ref int max, ref int cnt, ref int prev, List<int> result)
        {
            if (node == null) return;

            dfs(node.left, ref max, ref cnt, ref prev, result);
            if (node.val == prev)
            {
                cnt++;
            }
            else
            {
                if (cnt > max)
                {
                    result.Clear(); result.Add(prev); max = cnt;
                }
                else if (cnt == max)
                {
                    result.Add(prev);
                }
                prev = node.val; cnt = 1;
            }
            dfs(node.right, ref max, ref cnt, ref prev, result);
        }
    }
}
