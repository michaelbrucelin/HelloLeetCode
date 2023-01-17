using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1814
{
    public class Solution1814_2 : Interface1814
    {
        /// <summary>
        /// 与Solution1814逻辑一致，但是更多使用了API，例如数字反转就是利用字符串反转完成的
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountNicePairs(int[] nums)
        {
            const int MOD = 1000000007;
            Dictionary<int, int> buffer = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i] - Convert.ToInt32(new string(nums[i].ToString().Reverse().ToArray()));
                if (buffer.ContainsKey(val)) buffer[val]++; else buffer.Add(val, 1);
            }

            int result = 0;
            foreach (int val in buffer.Values)
            {
                if (val < 2) continue;
                result += (int)((((long)val) * (val - 1) >> 1) % MOD);
                result %= MOD;
            }

            return result;
        }
    }
}
