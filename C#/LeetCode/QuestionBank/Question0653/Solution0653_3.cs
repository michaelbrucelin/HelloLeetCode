using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0653
{
    public class Solution0653_3 : Interface0653
    {
        /// <summary>
        /// 有序数组 + 双指针 + 二分查找
        /// 与Solution0653一样，只不过左右指针不再是一步一步的移动，而是使用二分法快速移动
        /// 右边快速找到最后一个（从左到右）“和”小于等于k的位置
        /// 左边快速占到第一个（从左到右）“和”大于等于k的位置
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool FindTarget(TreeNode root, int k)
        {
            List<int> nums = new List<int>();
            BSTToArray(root, nums);

            int left = 0, right = nums.Count - 1, add;
            while (left < right)
            {
                add = nums[left] + nums[right];
                if (add == k) return true;
                if (add < k)
                    left = BinarySearchLeft(nums, left + 1, right - 1, k - nums[right]);
                else
                    right = BinarySearchRight(nums, left + 1, right - 1, k - nums[left]);
            }

            return false;
        }

        private void BSTToArray(TreeNode root, List<int> nums)
        {
            if (root == null) return;
            if (root.left != null) BSTToArray(root.left, nums);
            nums.Add(root.val);
            if (root.right != null) BSTToArray(root.right, nums);
        }

        private int BinarySearchLeft(List<int> nums, int left, int right, int target)
        {
            int result = right + 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (nums[mid] >= target)
                {
                    result = mid; right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return result;
        }

        private int BinarySearchRight(List<int> nums, int left, int right, int target)
        {
            int result = left - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (nums[mid] <= target)
                {
                    result = mid; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }
    }
}
