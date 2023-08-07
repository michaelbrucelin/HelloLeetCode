using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0914
{
    public class Solution0914 : Interface0914
    {
        /// <summary>
        /// 分组 + 公约数
        /// 1. 将数组中的元素按照元素的值分组，并统计数量
        /// 2. 如果所有值的数量有公约数即有解，反之无解
        /// 3. 求多个值的最大公约数的方法：
        ///     暴力求解
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

            int min = deck.Length;
            foreach (int cnt in dic.Values) min = Math.Min(cnt, min);

            bool flag;
            for (int i = 2; i <= min; i++)
            {
                flag = true;
                foreach (int cnt in dic.Values)
                {
                    if (cnt % i != 0) { flag = false; break; }
                }
                if (flag) return true;
            }

            return false;
        }
    }
}
