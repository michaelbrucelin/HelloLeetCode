using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1488
{
    public class Solution1488_oth_2 : Interface1488
    {
        /// <summary>
        /// 并查集
        /// 逻辑没问题，TLE，猜测是由于并查集没有合并导致的，暂时不改了
        /// </summary>
        /// <param name="rains"></param>
        /// <returns></returns>
        public int[] AvoidFlood(int[] rains)
        {
            int len = rains.Length;
            int[] result = new int[len];

            Dictionary<int, int> full = new Dictionary<int, int>();
            int[] uf = new int[len + 1];
            for (int i = 0, rain; i < len; i++)
            {
                rain = rains[i];
                if (rain > 0)
                {
                    uf[i] = i + 1;
                    result[i] = -1;
                    if (full.TryGetValue(rain, out int _i))
                    {
                        int _todo = find(_i + 1, i);
                        if (_todo == -1) return [];
                        result[_todo] = rain;
                        full[rain] = i;
                    }
                    else
                    {
                        full.Add(rain, i);
                    }
                }
                else
                {
                    uf[i] = i;
                    result[i] = 1;
                }
            }

            return result;

            int find(int x, int end)
            {
                if (x == end) return -1;
                if (uf[x] == x)
                {
                    uf[x] = uf[x + 1];
                    return x;
                }
                return find(uf[x], end);
            }
        }
    }
}
