using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2748
{
    public class Solution2748_3 : Interface2748
    {
        private static readonly int[][] map = new int[][]
        {
            new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            new int[]{ 1, 3, 5, 7, 9 },
            new int[]{ 1, 2, 4, 5, 7, 8 },
            new int[]{ 1, 3, 5, 7, 9 },
            new int[]{ 1, 2, 3, 4, 6, 7, 8, 9 },
            new int[]{ 1, 5, 7 },
            new int[]{ 1, 2, 3, 4, 5, 6, 8, 9 },
            new int[]{ 1, 3, 5, 7, 9 },
            new int[]{ 1, 2, 4, 5, 7, 8 }
        };

        /// <summary>
        /// 非暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountBeautifulPairs(int[] nums)
        {
            int result = 0, len = nums.Length;
            int[] cnt = new int[10];
            for (int i = 1, y, num; i < len; i++)
            {
                cnt[FirstDigit(nums[i - 1])]++;
                y = nums[i] % 10 - 1;
                foreach (int x in map[y]) result += cnt[x];
            }

            return result;
        }

        private int FirstDigit(int x)
        {
            while (x > 9) x /= 10;
            return x;
        }
    }
}
