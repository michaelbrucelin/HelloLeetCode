using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1806
{
    public class Solution1806 : Interface1806
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ReinitializePermutation(int n)
        {
            int[] map = new int[n];
            for (int i = 0; i < n; i++) map[i] = (i & 1) != 1 ? i >> 1 : (n + i - 1) >> 1;

            int[] nums = new int[n];
            for (int i = 0; i < n; i++) nums[i] = i;

            int steps = 0;
            while (true)
            {
                steps++;
                int[] _nums = new int[n];
                for (int i = 0; i < n; i++) _nums[i] = nums[map[i]];
                bool isback = true;
                for (int i = 0; i < n; i++)  // Enumerable.SequenceEqual(num, _num)
                {
                    if (_nums[i] != i)
                    {
                        nums = _nums; isback = false;
                        break;
                    }
                }
                if (isback) break;
            }

            return steps;
        }
    }
}
