using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2364
{
    public class Solution2364_2 : Interface2364
    {
        /// <summary>
        /// 逻辑同Solution2364，Solution2364是反向求解，这里改为正向求解
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long CountBadPairs(int[] nums)
        {
            long result = 0, len = nums.Length;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0, key; i < len; i++)
            {
                key = nums[i] - i;
                if (map.ContainsKey(key))
                {
                    result += i - map[key];
                    map[key]++;
                }
                else
                {
                    result += i;
                    map.Add(key, 1);
                }
            }

            return result;
        }
    }
}
