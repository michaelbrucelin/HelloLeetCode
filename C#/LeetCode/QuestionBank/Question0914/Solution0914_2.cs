using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0914
{
    public class Solution0914_2 : Interface0914
    {
        /// <summary>
        /// 分组 + 公约数
        /// 1. 将数组中的元素按照元素的值分组，并统计数量
        /// 2. 如果所有值的数量有公约数即有解，反之无解
        /// 3. 求多个值的最大公约数的方法：
        ///     先求出前两个值的最大公约数，然后用这个公约数与第3个值求最大公约数，依此类推
        /// </summary>
        /// <param name="deck"></param>
        /// <returns></returns>
        public bool HasGroupsSizeX(int[] deck)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0, j; i < deck.Length; i++)
            {
                j = deck[i]; if (dic.ContainsKey(j)) dic[j]++; else dic.Add(j, 1);
            }

            int gcd = dic.First().Value;
            foreach (int i in dic.Values)
            {
                gcd = GetGCD(gcd, i);
                if (gcd == 1) return false;
            }

            return true;
        }

        private int GetGCD(int x, int y)
        {
            if (x == y) return x;

            int move = 0;
            while (x != y)
            {
                if ((x & 1) == 0 && (y & 1) == 0)
                {
                    x >>= 1; y >>= 1; move++;
                }
                else if ((x & 1) == 0 && (y & 1) == 1) x >>= 1;
                else if ((x & 1) == 1 && (y & 1) == 0) y >>= 1;
                else
                {
                    if (x > y) x = (x - y) >> 1; else y = (y - x) >> 1;
                }
            }

            return x << move;
        }
    }
}
