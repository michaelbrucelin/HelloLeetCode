using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0688
{
    public class Solution0688_2 : Interface0688
    {
        private static readonly (int r, int c)[] dirs = [(2, 1), (2, -1), (-2, 1), (-2, -1), (1, 2), (1, -2), (-1, 2), (-1, -2)];

        /// <summary>
        /// BFS
        /// 逻辑同Solution0688，将其中的队列改为字典来优化空间复杂度
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public double KnightProbability(int n, int k, int row, int column)
        {
            if (k == 0) return 1D;

            Dictionary<(int r, int c), double> queue = new Dictionary<(int r, int c), double>(), _queue;
            queue.Add((row, column), 1);
            int _k = k;
            while (_k-- > 0)
            {
                _queue = new Dictionary<(int r, int c), double>();
                foreach (var kv in queue)
                {
                    for (int j = 0, _r = 0, _c = 0; j < 8; j++)
                    {
                        _r = kv.Key.r + dirs[j].r; _c = kv.Key.c + dirs[j].c;
                        if (_r >= 0 && _r < n && _c >= 0 && _c < n)
                        {
                            _queue.TryAdd((_r, _c), 0); _queue[(_r, _c)] += kv.Value;
                        }
                    }
                }
                queue = _queue;
            }

            double result = queue.Values.Sum();
            for (int i = 0; i < k; i++) result /= 8;
            return result;
        }

        /// <summary>
        /// 逻辑同KnightProbability()，将字典替换为二维数组
        /// 无论是时间复杂度，还是空间复杂度都提高了很多
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public double KnightProbability2(int n, int k, int row, int column)
        {
            if (k == 0) return 1D;

            double[,] queue = new double[n, n], _queue = new double[n, n];
            queue[row, column] = 1;
            int _k = k;
            while (_k-- > 0)
            {
                for (int r = 0; r < n; r++) for (int c = 0; c < n; c++)
                    {
                        for (int j = 0, _r = 0, _c = 0; j < 8; j++)
                        {
                            _r = r + dirs[j].r; _c = c + dirs[j].c;
                            if (_r >= 0 && _r < n && _c >= 0 && _c < n)
                            {
                                _queue[_r, _c] += queue[r, c];
                            }
                        }
                    }
                for (int r = 0; r < n; r++) for (int c = 0; c < n; c++)
                    {
                        queue[r, c] = _queue[r, c]; _queue[r, c] = 0;
                    }
            }

            double result = 0;
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++) result += queue[r, c];
            for (int i = 0; i < k; i++) result /= 8;
            return result;
        }
    }
}
