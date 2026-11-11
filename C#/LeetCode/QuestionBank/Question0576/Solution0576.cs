using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0576
{
    public class Solution0576 : Interface0576
    {
        /// <summary>
        /// dfs + 记忆化搜索
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="maxMove"></param>
        /// <param name="startRow"></param>
        /// <param name="startColumn"></param>
        /// <returns></returns>
        public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
        {
            const int MOD = (int)1e9 + 7;
            int[] dirs = [-1, 0, 1, 0, -1];
            Dictionary<(int, int, int), int> memory = new Dictionary<(int, int, int), int>();
            return dfs(m, n, startRow, startColumn, maxMove, MOD, dirs, memory);

            static int dfs(int m, int n, int r, int c, int move, int mod, int[] dirs, Dictionary<(int, int, int), int> memory)
            {
                if (move == 0) return 0;
                if (memory.ContainsKey((r, c, move))) return memory[(r, c, move)];

                int cnt = 0;
                for (int i = 0, _r, _c; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (_r < 0 || _r >= m || _c < 0 || _c >= n)
                    {
                        cnt++;
                    }
                    else
                    {
                        cnt += dfs(m, n, _r, _c, move - 1, mod, dirs, memory);
                        cnt %= mod;
                    }
                }

                memory.Add((r, c, move), cnt);
                return cnt;
            }
        }
    }
}
