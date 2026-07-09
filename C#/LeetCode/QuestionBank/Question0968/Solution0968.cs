using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0968
{
    public class Solution0968 : Interface0968
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 
        /// 不写了，以后再写
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinCameraCover(TreeNode root)
        {
            Dictionary<TreeNode, int[]> memory = new Dictionary<TreeNode, int[]>();

            return Math.Min(memory[root][0], memory[root][1]);

            int dfs(TreeNode node, int monitor)
            {
                if (memory[node][monitor] > 0) return memory[node][monitor];

                int result = -1;
                switch ((node.left, node.right, monitor))
                {
                    case (null, null, _):
                        result = 1;
                        break;
                    case (_, null, 1):
                        result = Math.Min(dfs(node.left, 1), dfs(node.left, 0));
                        break;
                    case (_, null, 0):

                        break;
                    case (null, _, 1):
                        break;
                    case (null, _, 0):
                        break;
                    case (_, _, 1):
                        break;
                    case (_, _, 0):
                        break;
                }

                memory[node][monitor] = result;
                return result;
            }
        }
    }
}
