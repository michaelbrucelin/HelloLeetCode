using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2476
{
    public class Solution2476 : Interface2476
    {
        /// <summary>
        /// 二叉搜索树
        /// 逻辑没有问题，但是提交竟然TLE，是因为二叉搜索树不是平衡树导致的
        /// </summary>
        /// <param name="root"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public IList<IList<int>> ClosestNodes(TreeNode root, IList<int> queries)
        {
            int[][] result = new int[queries.Count][];
            for (int i = 0; i < result.Length; i++) result[i] = new int[] { -1, -1 };
            if (root == null) return result;

            TreeNode ptr;
            for (int i = 0, val; i < queries.Count; i++)
            {
                val = queries[i];
                ptr = root; while (ptr != null)
                {
                    if (ptr.val == val) { result[i][0] = val; break; }
                    if (ptr.val < val)
                    {
                        result[i][0] = ptr.val; ptr = ptr.right;
                    }
                    else  // if (ptr.val > val)
                    {
                        ptr = ptr.left;
                    }
                }

                ptr = root; while (ptr != null)
                {
                    if (ptr.val == val) { result[i][1] = val; break; }
                    if (ptr.val > val)
                    {
                        result[i][1] = ptr.val; ptr = ptr.left;
                    }
                    else  // if (ptr.val < val)
                    {
                        ptr = ptr.right;
                    }
                }
            }

            return result;
        }
    }
}
