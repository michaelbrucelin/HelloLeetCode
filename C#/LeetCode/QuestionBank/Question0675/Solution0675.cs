using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0675
{
    public class Solution0675 : Interface0675
    {
        /// <summary>
        /// 暴力（排序 + BFS）
        /// 1. 如果所有 >0 的格子是一个连通量，有解，否则，无解
        /// 2. 如果有解，从一开始，砍树的顺序就固定了
        /// 3. 砍完当前的树，BFS找出最少的步数到达下一颗树
        /// </summary>
        /// <param name="forest"></param>
        /// <returns></returns>
        public int CutOffTree(IList<IList<int>> forest)
        {
            int rcnt = forest.Count, ccnt = forest[0].Count;
            List<(int, int)> trees = new List<(int, int)>();
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (forest[r][c] > 1) trees.Add((r, c));
            trees.Sort((x, y) => forest[x.Item1][x.Item2] - forest[y.Item1][y.Item2]);
            if (trees[0] != (0, 0)) trees.Insert(0, (0, 0));

            int result = 0, cnt = trees.Count, step;
            for (int i = 1; i < cnt; i++) if ((step = count_step(forest, trees[i - 1], trees[i])) != -1) result += step; else return -1;
            return result;

            static int count_step(IList<IList<int>> forest, (int, int) s, (int, int) e)
            {
                int step = 0, rcnt = forest.Count, ccnt = forest[0].Count;
                Queue<(int, int)> queue = new Queue<(int, int)>();
                queue.Enqueue(s);
                bool[,] visited = new bool[rcnt, ccnt];
                visited[s.Item1, s.Item2] = true;
                int r, c, _r, _c;
                int[] dirs = [-1, 0, 1, 0, -1];
                while (queue.Count > 0)
                {
                    step++;
                    for (int i = queue.Count; i > 0; i--)
                    {
                        (r, c) = queue.Dequeue();
                        for (int j = 0; j < 4; j++)
                        {
                            _r = r + dirs[j]; _c = c + dirs[j + 1];
                            if (_r < 0 || _r >= rcnt || _c < 0 || _c >= ccnt || forest[_r][_c] == 0) continue;
                            if ((_r, _c) == e) return step;
                            if (!visited[_r, _c]) { queue.Enqueue((_r, _c)); visited[_r, _c] = true; }
                        }
                    }
                }

                return -1;
            }
        }
    }
}
