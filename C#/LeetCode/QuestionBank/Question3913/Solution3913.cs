using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3913
{
    public class Solution3913 : Interface3913
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string SortVowels(string s)
        {
            char[] chars = [.. s];
            char[] map = ['a', 'e', 'i', 'o', 'u'];
            int len = s.Length;
            int[][] info = [[0, len], [0, len], [0, len], [0, len], [0, len]];
            List<int> idxs = [];
            for (int i = 0; i < len; i++) switch (chars[i])
                {
                    case 'a': info[0][0]++; info[0][1] = Math.Min(info[0][1], i); idxs.Add(i); break;
                    case 'e': info[1][0]++; info[1][1] = Math.Min(info[1][1], i); idxs.Add(i); break;
                    case 'i': info[2][0]++; info[2][1] = Math.Min(info[2][1], i); idxs.Add(i); break;
                    case 'o': info[3][0]++; info[3][1] = Math.Min(info[3][1], i); idxs.Add(i); break;
                    case 'u': info[4][0]++; info[4][1] = Math.Min(info[4][1], i); idxs.Add(i); break;
                    default: break;
                }
            if (idxs.Count == 0) return s;

            int[] order = [0, 1, 2, 3, 4];
            Array.Sort(order, (x, y) => info[x][0] != info[y][0] ? info[y][0] - info[x][0] : info[x][1] - info[y][1]);
            int p = 0;
            foreach (int idx in idxs)
            {
                if (info[order[p]][0] == 0) p++;
                chars[idx] = map[order[p]];
                info[order[p]][0]--;
            }

            return new string(chars);
        }
    }
}
