using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0688
{
    public class Solution0688 : Interface0688
    {
        private static readonly (int r, int c)[] dirs = [(2, 1), (2, -1), (-2, 1), (-2, -1), (1, 2), (1, -2), (-1, 2), (-1, -2)];

        /// <summary>
        /// BFS
        /// 逻辑没问题，MLE，参考测试用例03
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public double KnightProbability(int n, int k, int row, int column)
        {
            if (k == 0) return 1D;

            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
            queue.Enqueue((row, column));
            (int r, int c) item; int cnt, _k = k;
            while (_k-- > 0)
            {
                if ((cnt = queue.Count) == 0) return 0;
                for (int i = 0; i < cnt; i++)
                {
                    item = queue.Dequeue();
                    for (int j = 0, _r = 0, _c = 0; j < 8; j++)
                    {
                        _r = item.r + dirs[j].r; _c = item.c + dirs[j].c;
                        if (_r >= 0 && _r < n && _c >= 0 && _c < n) queue.Enqueue((_r, _c));
                    }
                }
            }

            double result = queue.Count;
            for (int i = 0; i < k; i++) result /= 8;
            return result;
        }
    }
}
