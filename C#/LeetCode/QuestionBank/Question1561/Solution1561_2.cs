using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1561
{
    public class Solution1561_2 : Interface1561
    {
        /// <summary>
        /// 贪心 + 计数排序
        /// 逻辑同Solution1561，将大顶堆换成计数排序
        /// </summary>
        /// <param name="piles"></param>
        /// <returns></returns>
        public int MaxCoins(int[] piles)
        {
            int[] freq = new int[10001];  // 可以考虑使用piles.Max + 1，而不是10001
            foreach (int pile in piles) freq[pile]++;

            int result = 0, times = piles.Length / 3, carry = 0, total, p = 10000;
            while (times > 0)
            {
                if (freq[p] == 0) { p--; continue; }
                total = freq[p] + carry;
                if ((total >> 1) >= times)
                {
                    result += p * times;
                    break;
                }
                else
                {
                    result += p * (total >> 1);
                    times -= total >> 1;
                    carry = total & 1;
                    p--;
                }
            }

            return result;
        }
    }
}
