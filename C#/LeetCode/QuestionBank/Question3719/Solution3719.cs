using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3719
{
    public class Solution3719 : Interface3719
    {
        /// <summary>
        /// 暴力
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestBalanced(int[] nums)
        {
            int result = 0, len = nums.Length;
            Dictionary<int, int> even = [], odd = [];
            for (int i = 0; i < len; i++)
            {
                even.Clear(); odd.Clear();
                for (int j = i, num; j < len; j++)
                {
                    num = nums[j];
                    if ((num & 1) == 0)
                    {
                        if (even.TryGetValue(num, out int value)) even[num] = ++value; else even.Add(num, 1);
                    }
                    else
                    {
                        if (odd.TryGetValue(num, out int value)) odd[num] = ++value; else odd.Add(num, 1);
                    }
                    if (even.Count == odd.Count) result = Math.Max(result, j - i + 1);
                }
            }

            return result;
        }
    }
}
