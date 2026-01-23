using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2161
{
    public class Solution2161_2 : Interface2161
    {
        /// <summary>
        /// 原地
        /// 按题目给定的数据量会TLE，写着玩的
        /// 
        /// 提交竟然没有TLE... ...
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="pivot"></param>
        /// <returns></returns>
        public int[] PivotArray(int[] nums, int pivot)
        {
            int swap, len = nums.Length;
            for (int i = 0; i < len; i++) if (nums[i] >= pivot)
                {
                    for (int j = i + 1; j < len; j++) if (nums[j] < pivot)
                        {
                            swap = nums[j];
                            for (int k = j; k > i; k--) nums[k] = nums[k - 1];
                            nums[i] = swap;
                            goto CONTINUE;
                        }
                    break;
                CONTINUE:;
                }
            for (int i = len - 1; i >= 0 && nums[i] >= pivot; i--) if (nums[i] == pivot)
                {
                    for (int j = i - 1; j >= 0 && nums[j] >= pivot; j--) if (nums[j] > pivot)
                        {
                            swap = nums[j];
                            for (int k = j; k < i; k++) nums[k] = nums[k + 1];
                            nums[i] = swap;
                            goto CONTINUE;
                        }
                    break;
                CONTINUE:;
                }

            return nums;
        }
    }
}
