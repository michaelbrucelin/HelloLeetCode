using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0653
{
    public class Solution0653_2 : Interface0653
    {
        /// <summary>
        /// 有序数组 + 双指针
        /// 1. 将二叉查找树转为有序数组（中序遍历）
        /// 2. 双指针找结果
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
                if (add < k) left++; else right--;
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
    }
}
