using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0157
{
    public class Solution0157_2 : Interface0157
    {
        /// <summary>
        /// 回溯
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public string[] GoodsOrder(string goods)
        {
            List<string> result = [];
            int len = goods.Length;
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < len; i++) if (map.TryGetValue(goods[i], out int val)) map[goods[i]] = ++val; else map.Add(goods[i], 1);
            char[] buffer = new char[len];
            backtrack(0);

            return [.. result];

            void backtrack(int idx)
            {
                if (idx == len) { result.Add(new string(buffer)); return; }
                foreach (char c in map.Keys) if (map[c] > 0)
                    {
                        buffer[idx] = c; map[c]--;
                        backtrack(idx + 1);
                        map[c]++;
                    }
            }
        }
    }
}
