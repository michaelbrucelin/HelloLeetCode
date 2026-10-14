using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2913
{
    public class Soluition2913 : Interface2913
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SumCounts(IList<int> nums)
        {
            int result = 0, cnt, max = nums[0], len = nums.Count;
            for (int i = 1; i < len; i++) max = Math.Max(max, nums[i]);
            bool[] set = new bool[max + 1];
            for (int i = 0; i < len; i++)
            {
                Array.Fill(set, false);
                cnt = 0;
                for (int j = i; j < len; j++)
                {
                    if (!set[nums[j]]) { cnt++; set[nums[j]] = true; }
                    result += cnt * cnt;
                }
            }

            return result;
        }
    }
}
