using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1900
{
    public class Solution1900 : Interface1900
    {
        /// <summary>
        /// dfs + 记忆化搜索
        /// 如果 x + y == n + 1，结果为 [1, 1]，否则 x 和 y 同时进入下一轮，问题在于怎样遍历下一轮所有的可能性
        /// 二进制枚举 [0, n/2]，0 表示两支队伍中编号小的队伍获胜，1 表示编号大的队伍获胜
        /// </summary>
        /// <param name="n"></param>
        /// <param name="firstPlayer"></param>
        /// <param name="secondPlayer"></param>
        /// <returns></returns>
        public int[] EarliestAndLatest(int n, int firstPlayer, int secondPlayer)
        {
            if (firstPlayer + secondPlayer == n + 1) return [1, 1];
            int[,,,] memory = new int[n + 1, n + 1, n + 1, 2];
            dfs(n, firstPlayer, secondPlayer);
            return [memory[n, firstPlayer, secondPlayer, 0], memory[n, firstPlayer, secondPlayer, 1]];

            void dfs(int n, int x, int y)
            {
                if (memory[n, x, y, 0] > 0) return;

                if (x + y == n + 1)
                {
                    memory[n, x, y, 0] = memory[n, x, y, 1] = 1;
                }
                else
                {
                    int min = 6, max = 0, odd = n & 1, width = n >> 1, limit = (1 << (n >> 1)) - 1;
                    for (int _n = 0; _n <= limit; _n++)
                    {
                        string info = Convert.ToString(_n, 2).PadLeft(width, '0');
                        int pl = 1, pr = width + odd, _x = 0, _y = 0, _min, _max;
                        for (int i = 0; i < width; i++)
                        {
                            if (info[i] == '0')
                            {
                                if (n - i == x || n - i == y) goto CONTUNUE;
                                if (i + 1 == x) _x = pl; else if (i + 1 == y) _y = pl;
                                pl++;
                            }
                            else
                            {
                                if (i + 1 == x || i + 1 == y) goto CONTUNUE;
                                if (n - i == x) _x = pr; else if (n - i == y) _y = pr;
                                pr--;
                            }
                            if (_x > 0 && _y > 0) break;
                        }
                        if (_x == 0) _x = pl; else if (_y == 0) _y = pl;  // 中间轮空的位置，pl == pr
                        if (_x > _y) (_x, _y) = (_y, _x);

                        dfs((n + 1) >> 1, _x, _y);
                        _min = memory[(n + 1) >> 1, _x, _y, 0] + 1;
                        _max = memory[(n + 1) >> 1, _x, _y, 1] + 1;

                        min = Math.Min(min, _min);
                        max = Math.Max(max, _max);
                    CONTUNUE:;
                    }

                    memory[n, x, y, 0] = min;
                    memory[n, x, y, 1] = max;
                }
            }
        }

        /// <summary>
        /// 逻辑完全同EarliestAndLatest()，做了一处剪枝
        /// </summary>
        /// <param name="n"></param>
        /// <param name="firstPlayer"></param>
        /// <param name="secondPlayer"></param>
        /// <returns></returns>
        public int[] EarliestAndLatest2(int n, int firstPlayer, int secondPlayer)
        {
            if (firstPlayer + secondPlayer == n + 1) return [1, 1];
            int[,,,] memory = new int[n + 1, n + 1, n + 1, 2];
            dfs(n, firstPlayer, secondPlayer);
            return [memory[n, firstPlayer, secondPlayer, 0], memory[n, firstPlayer, secondPlayer, 1]];

            void dfs(int n, int x, int y)
            {
                if (memory[n, x, y, 0] > 0) return;

                if (x + y == n + 1)
                {
                    memory[n, x, y, 0] = memory[n, x, y, 1] = 1;
                }
                else
                {
                    int min = 6, max = 0, odd = n & 1, width = n >> 1, limit = (1 << (n >> 1)) - 1;
                    int px = x <= (n >> 1) ? x : (n + 1 - x), py = y <= (n >> 1) ? y : (n + 1 - y);
                    char cx = x <= (n >> 1) ? '0' : '1', cy = y <= (n >> 1) ? '0' : '1';
                    for (int _n = 0; _n <= limit; _n++)
                    {
                        string info = Convert.ToString(_n, 2).PadLeft(width, '0');
                        if ((px - 1 < info.Length && info[px - 1] != cx) || (py - 1 < info.Length && info[py - 1] != cy)) goto CONTUNUE;
                        int pl = 1, pr = width + odd, _x = 0, _y = 0, _min, _max;
                        for (int i = 0; i < width; i++)
                        {
                            if (info[i] == '0')
                            {
                                // if (n - i == x || n - i == y) goto CONTUNUE;
                                if (i + 1 == x) _x = pl; else if (i + 1 == y) _y = pl;
                                pl++;
                            }
                            else
                            {
                                // if (i + 1 == x || i + 1 == y) goto CONTUNUE;
                                if (n - i == x) _x = pr; else if (n - i == y) _y = pr;
                                pr--;
                            }
                            if (_x > 0 && _y > 0) break;
                        }
                        if (_x == 0) _x = pl; else if (_y == 0) _y = pl;  // 中间轮空的位置，pl == pr
                        if (_x > _y) (_x, _y) = (_y, _x);

                        dfs((n + 1) >> 1, _x, _y);
                        _min = memory[(n + 1) >> 1, _x, _y, 0] + 1;
                        _max = memory[(n + 1) >> 1, _x, _y, 1] + 1;

                        min = Math.Min(min, _min);
                        max = Math.Max(max, _max);
                    CONTUNUE:;
                    }

                    memory[n, x, y, 0] = min;
                    memory[n, x, y, 1] = max;
                }
            }
        }
    }
}
