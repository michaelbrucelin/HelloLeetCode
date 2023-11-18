using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2342
{
    public class Solution2342_2 : Interface2342
    {
        /// <summary>
        /// 与Solution2342逻辑一样，但是直接保留每个分组的两个最大值，而不是全部
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumSum(int[] nums)
        {
            Dictionary<int, int[]> dic = new Dictionary<int, int[]>();
            for (int i = 0, _sum; i < nums.Length; i++)
            {
                _sum = DigitSum(nums[i]);
                if (dic.ContainsKey(_sum))
                {
                    if (nums[i] > dic[_sum][0])
                    {
                        dic[_sum][1] = dic[_sum][0]; dic[_sum][0] = nums[i];
                    }
                    else if (nums[i] > dic[_sum][1])
                    {
                        dic[_sum][1] = nums[i];
                    }
                }
                else
                {
                    dic.Add(_sum, [nums[i], -1]);
                }
            }

            int result = -1;
            foreach (var arr in dic.Values)
                if (arr[1] != -1) result = Math.Max(result, arr[0] + arr[1]);

            return result;
        }

        private int DigitSum(int num)
        {
            int sum = 0;
            while (num > 0) { sum += num % 10; num /= 10; }
            return sum;
        }
    }
}
