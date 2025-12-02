using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3623
{
    public class Solution3623 : Interface3623
    {
        /// <summary>
        /// 排列组合
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int CountTrapezoids(int[][] points)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int[] p in points)
            {
                if (map.TryGetValue(p[1], out int value)) map[p[1]] = ++value; else map.Add(p[1], 1);
            }

            const int MOD = (int)1e9 + 7;
            List<long> list = [];
            foreach (int v in map.Values) list.Add(((1L * v * (v - 1)) >> 1) % MOD);

            long result = 0, sum = 0, cnt = list.Count;
            for (int i = 0; i < cnt; i++) sum = (sum + list[i]) % MOD;
            for (int i = 0; i < cnt; i++) result = result + list[i] * (sum - list[i]);

            return (int)((result >> 1) % MOD);
        }
    }
}
