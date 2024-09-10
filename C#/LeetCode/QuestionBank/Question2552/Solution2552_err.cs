using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2552
{
    public class Solution2552_err : Interface2552
    {
        /// <summary>
        /// 贡献法
        /// 1. 预处理
        ///     预处理每个元素左侧比自身小的元素的数量
        ///     预处理每个元素右侧比自身大的元素的数量
        ///     假定 index = i，则 nums[i] 左侧共有 i 个元素，假定其中有 x 个元素比 nums[i] 小，
        ///         那么 nums[i] 右侧有 N - nums[i] - (i - x) 个元素比 nums[i] 大
        ///         因为 nums 数组是 1 - N 的一个排列
        /// 2. 假定四元组为A B C D，枚举B C，计算每组B C的可能的四元素的数量（贡献）
        /// 时间复杂度：O(N^2)，不算小，先写出来试试
        /// 
        /// 题目看错了，题目要求的是：0 <= i < j < k < l < n && nums[i] < nums[k] < nums[j] < nums[l]
        ///             而这里求的是：0 <= i < j < k < l < n && nums[i] < nums[j] > nums[k] < nums[l]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long CountQuadruplets(int[] nums)
        {
            int len = nums.Length;
            int[] lcnt = new int[len], rcnt = new int[len];
            for (int i = 0, _lcnt; i < len; i++)
            {
                _lcnt = 0;
                for (int j = 0; j < i; j++) if (nums[j] < nums[i]) _lcnt++;
                lcnt[i] = _lcnt;
                rcnt[i] = len - nums[i] - (i - _lcnt);
            }

            long result = 0;
            for (int i = 0; i < len; i++) for (int j = i + 1; j < len; j++)
                {
                    if (nums[i] > nums[j]) result += ((long)lcnt[i]) * rcnt[j];
                }

            return result;
        }
    }
}
