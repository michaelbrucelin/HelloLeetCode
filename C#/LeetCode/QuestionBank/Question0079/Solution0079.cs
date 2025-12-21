using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0079
{
    public class Solution0079 : Interface0079
    {
        /// <summary>
        /// 回溯
        /// </summary>
        /// <param name="board"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Exist(char[][] board, string word)
        {
            int rcnt = board.Length, ccnt = board[0].Length, len = word.Length;
            int[] dirs = [-1, 0, 1, 0, -1];
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (board[r][c] == word[0])
                    {
                        visited.Clear();
                        visited.Add((r, c));
                        if (backtrack(r, c, 0)) return true;
                    }

            return false;

            bool backtrack(int r, int c, int id)
            {
                if (id + 1 == len) return true;
                int _r, _c;
                for (int i = 0; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && !visited.Contains((_r, _c)) && board[_r][_c] == word[id + 1])
                    {
                        visited.Add((_r, _c));
                        if (backtrack(_r, _c, id + 1)) return true;
                        visited.Remove((_r, _c));
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// 逻辑同Exist()，将其中的Hash改为数组
        /// 数组比Hash快不少
        /// </summary>
        /// <param name="board"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Exist2(char[][] board, string word)
        {
            int rcnt = board.Length, ccnt = board[0].Length, len = word.Length;
            int[] dirs = [-1, 0, 1, 0, -1];
            bool[,] visited = new bool[rcnt, ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (board[r][c] == word[0])
                    {
                        visited[r, c] = true;
                        if (backtrack(r, c, 0)) return true;
                        visited[r, c] = false;
                    }

            return false;

            bool backtrack(int r, int c, int id)
            {
                if (id + 1 == len) return true;
                int _r, _c;
                for (int i = 0; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && !visited[_r, _c] && board[_r][_c] == word[id + 1])
                    {
                        visited[_r, _c] = true;
                        if (backtrack(_r, _c, id + 1)) return true;
                        visited[_r, _c] = false;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// 逻辑同Exist2()，将其中的二维数组改为嵌套数组
        /// 二者速度差不多
        /// </summary>
        /// <param name="board"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Exist3(char[][] board, string word)
        {
            int rcnt = board.Length, ccnt = board[0].Length, len = word.Length;
            int[] dirs = [-1, 0, 1, 0, -1];
            bool[][] visited = new bool[rcnt][];
            for (int r = 0; r < rcnt; r++) visited[r] = new bool[ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (board[r][c] == word[0])
                    {
                        visited[r][c] = true;
                        if (backtrack(r, c, 0)) return true;
                        visited[r][c] = false;
                    }

            return false;

            bool backtrack(int r, int c, int id)
            {
                if (id + 1 == len) return true;
                int _r, _c;
                for (int i = 0; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && !visited[_r][_c] && board[_r][_c] == word[id + 1])
                    {
                        visited[_r][_c] = true;
                        if (backtrack(_r, _c, id + 1)) return true;
                        visited[_r][_c] = false;
                    }
                }

                return false;
            }
        }
    }
}
