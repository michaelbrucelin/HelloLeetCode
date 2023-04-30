using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0402
{
    public class Solution0402 : Interface0402
    {
        /// <summary>
        /// 分治
        /// 数组已经排序，如果数组长度是奇数，中间的元素是根，如果数组长度是偶数，中间靠右的元素是根
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums.Length == 0) return null;

            int mid = nums.Length >> 1;
            TreeNode root = new TreeNode(nums[mid]);
            root.left = BuildBST(nums, 0, mid - 1);
            root.right = BuildBST(nums, mid + 1, nums.Length - 1);

            return root;
        }

        private TreeNode BuildBST(int[] nums, int left, int right)
        {
            if (left > right) return null;
            int mid = left + ((right - left + 1) >> 1);
            TreeNode root = new TreeNode(nums[mid]);
            root.left = BuildBST(nums, left, mid - 1);
            root.right = BuildBST(nums, mid + 1, right);

            return root;
        }
    }
}
