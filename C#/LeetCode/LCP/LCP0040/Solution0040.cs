using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0040
{
    public class Solution0040 : Interface0040
    {
        /// <summary>
        /// 贪心，排序 + 策略
        /// 1. 排序，选出最大的cnt个数值
        /// 2. 如果这最大的cnt个数值的和是奇数
        ///     用其中最小的奇数换其余数字中最大的偶数
        ///     用其中最小的偶数换其余数字中最大的奇数
        /// 优化，选择最大的cnt个数字，可以有排序换成TopK算法
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="cnt"></param>
        /// <returns></returns>
        public int MaxmiumScore(int[] cards, int cnt)
        {
            int result = 0, len = cards.Length;
            if (cnt == 1)
            {
                for (int i = 0; i < len; i++) if ((cards[i] & 1) != 1) result = Math.Max(result, cards[i]);
                return result;
            }
            if (cnt == len)
            {
                for (int i = 0; i < len; i++) result += cards[i];
                return (result & 1) != 1 ? result : 0;
            }

            Array.Sort(cards);
            for (int i = 0; i < cnt; i++) result += cards[len - i - 1];
            if ((result & 1) != 1) return result;

            int result1 = 0, result2 = 0, p, q;
            // 最小的偶数换最大的奇数
            for (p = len - cnt; p < len; p++) if ((cards[p] & 1) != 1) break;
            if (p != len)
            {
                for (q = len - cnt - 1; q >= 0; q--) if ((cards[q] & 1) != 0) break;
                if (q != -1) result1 = result - cards[p] + cards[q];
            }

            // 最小的奇数换最大的偶数
            for (p = len - cnt; p < len; p++) if ((cards[p] & 1) != 0) break;
            if (p != len)
            {
                for (q = len - cnt - 1; q >= 0; q--) if ((cards[q] & 1) != 1) break;
                if (q != -1) result2 = result - cards[p] + cards[q];
            }

            return Math.Max(result1, result2);
        }
    }
}
