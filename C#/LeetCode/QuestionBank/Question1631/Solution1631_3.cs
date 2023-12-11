using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1631
{
    public class Solution1631_3 : Interface1631
    {
        private static readonly int[] dirs = new int[] { -1, 0, 1, 0, -1 };

        /// <summary>
        /// 回溯 + 记忆化
        /// 逻辑同Solution1631_2，添加记忆化搜索，目测速度提高不了多少，写着玩的
        /// 
        /// 感觉更慢了。。。可能是由于重复率很低，但是可能性很高，导致记忆化的成本更高了
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int MinimumEffortPath(int[][] heights)
        {
            int rcnt = heights.Length, ccnt = heights[0].Length;
            bool[,] visited = new bool[rcnt, ccnt];
            Dictionary<string, int>[,] memory = new Dictionary<string, int>[rcnt, ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) memory[r, c] = new Dictionary<string, int>();

            return dfs(heights, rcnt, ccnt, 0, 0, visited, memory);
        }

        private int dfs(int[][] heights, int rcnt, int ccnt, int r, int c, bool[,] visited, Dictionary<string, int>[,] memory)
        {
            if (r == rcnt - 1 && c == ccnt - 1) return 0;

            visited[r, c] = true;
            string key = Visited2String(visited, rcnt, ccnt);
            if (!memory[r, c].ContainsKey(key))
            {
                int result = int.MaxValue;
                for (int i = 0, _r, _c, _result; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && !visited[_r, _c])
                    {
                        _result = Math.Max(Math.Abs(heights[_r][_c] - heights[r][c]), dfs(heights, rcnt, ccnt, _r, _c, visited, memory));
                        result = Math.Min(result, _result);
                    }
                }
                memory[r, c].Add(key, result);
            }
            visited[r, c] = false;

            return memory[r, c][key];
        }

        /// <summary>
        /// 将visited数组转为string
        /// </summary>
        /// <returns></returns>
        private string Visited2String(bool[,] visited, int rcnt, int ccnt)
        {
            StringBuilder result = new StringBuilder();
            long key;
            if (ccnt < 64)  // long
            {
                for (int r = 0; r < rcnt; r++)
                {
                    key = 0;
                    for (int c = 0; c < ccnt; c++)
                    {
                        key <<= 1; if (visited[r, c]) key |= 1;
                    }
                    result.Append(key); result.Append(',');
                }
            }
            else            // long + long
            {
                for (int r = 0; r < rcnt; r++)
                {
                    key = 0;
                    for (int c = 0; c < 64; c++)
                    {
                        key <<= 1; if (visited[r, c]) key |= 1;
                    }
                    result.Append(key); result.Append(',');
                    key = 0;
                    for (int c = 64; c < ccnt; c++)
                    {
                        key <<= 1; if (visited[r, c]) key |= 1;
                    }
                    result.Append(key); result.Append(',');
                }
            }

            return result.ToString();
        }
    }
}
