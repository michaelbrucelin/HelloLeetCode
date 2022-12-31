using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1703
{
    public class Solution1703 : Interface1703
    {
        /// <summary>
        /// 滑动窗口
        /// 1. 找到一个区间，满足：
        ///     1.1 两端是1
        ///     1.2 总共有k个1
        /// 2. 将这个区间中间的0移到两端，离哪端近（哪边的1少），就向哪端移动
        /// 
        /// 算法是正确的，但是提交会超时，参考测试用例4
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinMoves(int[] nums, int k)
        {
            if (k == 1) return 0;

            int left = 0, len = nums.Length;
            while (left < len && nums[left] == 0) left++;  // 第一个窗口的左边界
            int cnt = 1, right = left + 1;
            while (right < len)
            {
                cnt += nums[right];
                if (cnt == k) break; else right++;         // 第一个窗口的右边界
            }
            int result = MoveSteps(nums, k, left, right);  // 第一个窗口的结果
            left++; right++;

            while (true)
            {
                while (left < len && nums[left] == 0) left++;
                if (left > len - k) break;
                while (right < len && nums[right] == 0) right++;
                if (right == len) break;

                int steps = MoveSteps(nums, k, left, right);
                if (steps < result) result = steps;

                left++; right++;
            }

            return result;
        }

        private int MoveSteps(int[] nums, int k, int left, int right)
        {
            int steps = 0, cnt_left = 1;
            for (int i = left + 1; i < right; i++)
            {
                if (nums[i] == 1)
                    cnt_left++;
                else
                    steps += Math.Min(cnt_left, k - cnt_left);
            }

            return steps;
        }
    }
}
