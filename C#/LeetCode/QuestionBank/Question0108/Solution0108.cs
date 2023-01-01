using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0108
{
    public class Solution0108 : Interface0108
    {
        /// <summary>
        /// 递归，分治
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums.Length == 1) return new TreeNode(nums[0]);

            return dfs(nums, 0, nums.Length - 1);
        }

        private TreeNode dfs(int[] nums, int left, int right)
        {
            if (left > right) return null;
            if (left == right) return new TreeNode(nums[left]);

            int mid = left + ((right - left) >> 1);
            TreeNode node = new TreeNode(nums[mid]);
            node.left = dfs(nums, left, mid - 1);
            node.right = dfs(nums, mid + 1, right);

            return node;
        }
    }
}
