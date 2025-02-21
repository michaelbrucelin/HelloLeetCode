using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0016
{
    public class Solution0016_3 : Interface0016
    {
        /// <summary>
        /// 排序 + 双指针
        /// 1. 数组排序
        /// 2. 枚举数组的每一项，作为3数之和中的第一个数，这样问题就变成余下两数的和最接近target-nums[i]了
        ///     在nums[i+1..]中使用双指针解决问题，道理同“11. 盛最多水的容器”
        ///     两个指针指向nums[i+1]与nums[-1]，求和
        ///         如果 和 = 目标，返回结果
        ///         如果 和 < 目标，左指针右移
        ///         如果 和 > 目标，右指针左移
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ThreeSumClosest(int[] nums, int target)
        {
            int result = nums[0] + nums[1] + nums[2], len = nums.Length;
            if (len == 3) return result;

            Array.Sort(nums);
            for (int i = 0, left = 0, right = 0, add = 0; i < len - 2; i++)
            {
                left = i + 1; right = len - 1;
                while (left < right)
                {
                    add = nums[i] + nums[left] + nums[right];
                    if (add == target) return target;
                    if (Math.Abs(add - target) < Math.Abs(result - target)) result = add;
                    if (add < target) left++; else right--;
                }
            }

            return result;
        }

        /// <summary>
        /// 与ThreeSumClosest()一样，做了部分剪枝优化
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ThreeSumClosest2(int[] nums, int target)
        {
            int result = nums[0] + nums[1] + nums[2], len = nums.Length;
            if (len == 3) return result;

            Array.Sort(nums);
            for (int i = 0, left = 0, right = 0, add = 0; i < len - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;  // 此时的解一定在上一轮已经计算过了
                left = i + 1; right = len - 1;
                while (left < right)
                {
                    add = nums[i] + nums[left] + nums[right];
                    if (add == target) return target;
                    if (Math.Abs(add - target) < Math.Abs(result - target)) result = add;
                    if (add < target) left++; else right--;
                }
            }

            return result;
        }
    }
}
