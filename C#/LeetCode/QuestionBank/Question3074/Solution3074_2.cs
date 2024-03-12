using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3074
{
    public class Solution3074_2 : Interface3074
    {
        /// <summary>
        /// 贪心 + 计数排序
        /// </summary>
        /// <param name="apple"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public int MinimumBoxes(int[] apple, int[] capacity)
        {
            int sum = 0;
            for (int i = 0; i < apple.Length; i++) sum += apple[i];
            int[] freq = new int[51];
            for (int i = 0; i < capacity.Length; i++) freq[capacity[i]]++;

            int result = 0, _sum = 0;
            for (int i = 50, cnt; i > 0; i--) if ((cnt = freq[i]) > 0)
                {
                    while (_sum < sum && cnt > 0)
                    {
                        _sum += i; cnt--; result++;
                    }
                }

            return result;
        }
    }
}
