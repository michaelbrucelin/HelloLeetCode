using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2748
{
    public class Solution2748_2 : Interface2748
    {
        private static readonly Dictionary<int, HashSet<int>> dic = new Dictionary<int, HashSet<int>>()
        {
            { 1, new HashSet<int>(){ 1, 2, 3, 4, 5, 6, 7, 8, 9 } },
            { 2, new HashSet<int>(){ 1, 3, 5, 7, 9 } },
            { 3, new HashSet<int>(){ 1, 2, 4, 5, 7, 8 } },
            { 4, new HashSet<int>(){ 1, 3, 5, 7, 9 } },
            { 5, new HashSet<int>(){ 1, 2, 3, 4, 6, 7, 8, 9 } },
            { 6, new HashSet<int>(){ 1, 5, 7 } },
            { 7, new HashSet<int>(){ 1, 2, 3, 4, 5, 6, 8, 9 } },
            { 8, new HashSet<int>(){ 1, 3, 5, 7, 9 } },
            { 9, new HashSet<int>(){ 1, 2, 4, 5, 7, 8 } }
        };

        /// <summary>
        /// 与Solution2748逻辑一样，但是预处理了检查两个数字是否互质，改为打表
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountBeautifulPairs(int[] nums)
        {
            int result = 0, len = nums.Length;
            for (int i = 0, x; i < len - 1; i++)
            {
                x = FirstDigit(nums[i]);
                for (int j = i + 1; j < len; j++)
                    if (dic[x].Contains(nums[j] % 10)) result++;
            }

            return result;
        }

        private static readonly bool[,] map = new bool[9, 10]
        {
            { false, true, true,  true,  true,  true,  true,  true,  true,  true  },
            { false, true, false, true,  false, true,  false, true,  false, true  },
            { false, true, true,  false, true,  true,  false, true,  true,  false },
            { false, true, false, true,  false, true,  false, true,  false, true  },
            { false, true, true,  true,  true,  false, true,  true,  true,  true  },
            { false, true, false, false, false, true,  false, true,  false, false },
            { false, true, true,  true,  true,  true,  true,  false, true,  true  },
            { false, true, false, true,  false, true,  false, true,  false, true  },
            { false, true, true,  false, true,  true,  false, true,  true,  false }
        };

        public int CountBeautifulPairs2(int[] nums)
        {
            int result = 0, len = nums.Length;
            for (int i = 0, x; i < len - 1; i++)
            {
                x = FirstDigit(nums[i]) - 1;
                for (int j = i + 1; j < len; j++)
                    if (map[x, nums[j] % 10]) result++;
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
