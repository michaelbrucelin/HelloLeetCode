using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2352
{
    public class Solution2352_2 : Interface2352
    {
        /// <summary>
        /// 哈希
        /// 对矩阵的行与列哈希化，然后再枚举，O(3n^2) = O(n^2)
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int EqualPairs(int[][] grid)
        {
            Dictionary<string, int> rows = new Dictionary<string, int>();
            Dictionary<string, int> cols = new Dictionary<string, int>();
            int len = grid.Length; StringBuilder sb = new StringBuilder();
            for (int r = 0; r < len; r++)
            {
                sb.Clear();
                for (int i = 0; i < len; i++) sb.Append($"{grid[r][i]},");
                string key = sb.ToString();
                if (rows.ContainsKey(key)) rows[key]++; else rows.Add(key, 1);
            }
            for (int c = 0; c < len; c++)
            {
                sb.Clear();
                for (int i = 0; i < len; i++) sb.Append($"{grid[i][c]},");
                string key = sb.ToString();
                if (cols.ContainsKey(key)) cols[key]++; else cols.Add(key, 1);
            }

            int result = 0;
            foreach (var kv in rows)
                if (cols.ContainsKey(kv.Key)) result += kv.Value * cols[kv.Key];

            return result;
        }
    }
}
