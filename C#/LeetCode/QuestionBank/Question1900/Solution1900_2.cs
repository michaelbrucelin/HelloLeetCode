using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1900
{
    public class Solution1900_2 : Interface1900
    {
        /// <summary>
        /// dfs + 记忆化搜索
        /// 逻辑同Solution1900，二进制枚举的时候直接不枚举已知结果的位置
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
                else if (n == 3)
                {
                    memory[n, x, y, 0] = memory[n, x, y, 1] = 2;
                }
                else
                {
                    int px = x <= (n >> 1) ? x : (n + 1 - x), py = y <= (n >> 1) ? y : (n + 1 - y);
                    char cx = x <= (n >> 1) ? '0' : '1', cy = y <= (n >> 1) ? '0' : '1';
                    if (px > py) { (px, py) = (py, px); (cx, cy) = (cy, cx); }
                    int min = 6, max = 0, odd = n & 1, width = n >> 1, _width = (odd == 1 && py == width + 1) ? 1 : 2;
                    int limit = (1 << ((n >> 1) - _width)) - 1;
                    for (int _n = 0; _n <= limit; _n++)
                    {
                        string info = Convert.ToString(_n, 2).PadLeft(width - _width, '0');
                        if (py - 2 < info.Length)
                            info = $"{info[0..(px - 1)]}{cx}{info[(px - 1)..(py - 2)]}{cy}{info[py - 2]}";
                        else
                            info = $"{info[0..(px - 1)]}{cx}{info[(px - 1)..(py - 2)]}{cy}";
                        int pl = 1, pr = width + odd, _x = 0, _y = 0, _min, _max;
                        for (int i = 0; i < width; i++)
                        {
                            if (info[i] == '0')
                            {
                                if (i + 1 == x) _x = pl; else if (i + 1 == y) _y = pl;
                                pl++;
                            }
                            else
                            {
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
                    }

                    memory[n, x, y, 0] = min;
                    memory[n, x, y, 1] = max;
                }
            }
        }
    }
}
