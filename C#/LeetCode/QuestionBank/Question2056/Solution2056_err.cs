using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2056
{
    public class Solution2056_err : Interface2056
    {
        private static readonly Dictionary<string, (int r, int c)[]> dirs = new Dictionary<string, (int r, int c)[]>
        {
            { "rook", [(1, 0), (-1, 0), (0, 1), (0, -1)] },
            { "bishop", [(1, 1), (1, -1), (-1, 1), (-1, -1)] },
            { "queen", [(1, 0), (-1, 0), (0, 1), (0, -1), (1, 1), (1, -1), (-1, 1), (-1, -1)] }
        };

        /// <summary>
        /// 容斥 + 排列组合 + BFS
        /// 每一种棋子的可能性相乘，是全部可能
        /// 枚举每一种棋子行进的方向，BFS，找出冲突的可能
        /// 当棋子在(r, c)位置时，车 有 14 + 1 种可能
        ///                       象 有 Min(r, c, 9-r, 9-c) * 2 + 5 + 1 种可能
        ///                       后 有 14 + Min(r, c, 9-r, 9-c) * 2 + 5 + 1 种可能
        /// 
        /// 这道题的编码难度远大于逻辑难度，硬编码
        /// 
        /// 思路差不多是对的，但是实际情况比这里的复杂，参考测试用例05
        /// </summary>
        /// <param name="pieces"></param>
        /// <param name="positions"></param>
        /// <returns></returns>
        public int CountCombinations(string[] pieces, int[][] positions)
        {
            int result = 1, n = pieces.Length;
            for (int i = 0, j = 1, r = 0, c = 0; i < n; i++)
            {
                if (pieces[i] == "rook")
                {
                    j = 15;
                }
                else
                {
                    r = positions[i][0]; c = positions[i][1];
                    j = Math.Min(Math.Min(r, 9 - r), Math.Min(c, 9 - c)) * 2 + 6;
                    if (pieces[i] == "queen") j += 14;
                }
                result *= j;
            }
            if (n == 1) return result;

            int[][] _pos = new int[n][];
            for (int i = 0; i < n; i++) _pos[i] = new int[2];
            if (n == 2)
            {
                (int r, int c)[] _dir = new (int r, int c)[2];
                bool[] flag = new bool[2];
                foreach (var d1 in dirs[pieces[0]]) foreach (var d2 in dirs[pieces[1]])
                    {
                        array_copy();
                        _dir[0] = d1; _dir[1] = d2;
                        Array.Fill(flag, false);
                        while (true)
                        {
                            for (int i = 0, _r = 0, _c = 0; i < n; i++)
                            {
                                _r = _pos[i][0] + _dir[i].r; _c = _pos[i][1] + _dir[i].c;
                                if (_r >= 1 && _r <= 8 && _c >= 1 && _c <= 8)
                                {
                                    _pos[i][0] = _r; _pos[i][1] = _c;
                                }
                                else
                                {
                                    flag[i] = true;
                                }
                            }
                            if (flag[0] && flag[1]) break;
                            if (_pos[0][0] == _pos[1][0] && _pos[0][1] == _pos[1][1]) result--;
                        }
                    }
            }
            else if (n == 3)
            {
                foreach (var d1 in dirs[pieces[0]]) foreach (var d2 in dirs[pieces[1]]) foreach (var d3 in dirs[pieces[2]])
                        {

                        }
            }
            else  // if (n == 4)
            {
                foreach (var d1 in dirs[pieces[0]]) foreach (var d2 in dirs[pieces[1]]) foreach (var d3 in dirs[pieces[2]]) foreach (var d4 in dirs[pieces[3]])
                            {

                            }
            }

            return result;

            void array_copy()
            {
                for (int i = 0; i < n; i++)
                {
                    _pos[i][0] = positions[i][0];
                    _pos[i][1] = positions[i][1];
                }
            }
        }
    }
}
