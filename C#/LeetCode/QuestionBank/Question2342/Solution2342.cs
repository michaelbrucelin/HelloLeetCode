using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2342
{
    public class Solution2342 : Interface2342
    {
        /// <summary>
        /// 哈希分组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumSum(int[] nums)
        {
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
            for (int i = 0, _sum; i < nums.Length; i++)
            {
                _sum = DigitSum(nums[i]);
                if (dic.ContainsKey(_sum)) dic[_sum].Add(nums[i]);
                else dic.Add(_sum, new List<int>() { nums[i] });
            }

            int result = -1;
            foreach (var list in dic.Values) result = Math.Max(result, MaxSum(list));

            return result;
        }

        private int DigitSum(int num)
        {
            int sum = 0;
            while (num > 0) { sum += num % 10; num /= 10; }
            return sum;
        }

        private int MaxSum(List<int> nums)
        {
            if (nums.Count < 2) return -1;
            if (nums.Count == 2) return nums[0] + nums[1];

            int num1 = 0, num2 = -1;
            foreach (int num in nums)
            {
                if (num > num1)
                {
                    num2 = num1; num1 = num;
                }
                else if (num > num2)
                {
                    num2 = num;
                }
            }

            return num1 + num2;
        }
    }
}
