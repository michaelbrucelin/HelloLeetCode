using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2476
{
    public class Solution2476_2 : Interface2476
    {
        /// <summary>
        /// 中序遍历 + 二分查找
        /// 二叉查找树的中序遍历结果是升序的
        /// </summary>
        /// <param name="root"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public IList<IList<int>> ClosestNodes(TreeNode root, IList<int> queries)
        {
            int[][] result = new int[queries.Count][];
            for (int i = 0; i < result.Length; i++) result[i] = new int[] { -1, -1 };
            if (root == null) return result;

            List<int> inorder = new List<int>();
            InOrder(root, inorder);

            int cnt = inorder.Count, left, right, mid;
            for (int i = 0, val; i < queries.Count; i++)
            {
                val = queries[i];
                left = 0; right = cnt - 1;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (inorder[mid] == val) { result[i][0] = val; break; }
                    if (inorder[mid] < val)
                    {
                        result[i][0] = inorder[mid]; left = mid + 1;
                    }
                    else  // if (inorder[mid] > val)
                    {
                        right = mid - 1;
                    }
                }

                left = 0; right = cnt - 1;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (inorder[mid] == val) { result[i][1] = val; break; }
                    if (inorder[mid] > val)
                    {
                        result[i][1] = inorder[mid]; right = mid - 1;
                    }
                    else  // if (inorder[mid] < val)
                    {
                        left = mid + 1;
                    }
                }
            }

            return result;
        }

        private void InOrder(TreeNode root, List<int> list)
        {
            if (root == null) return;
            InOrder(root.left, list);
            list.Add(root.val);
            InOrder(root.right, list);
        }
    }
}
