using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0756
{
    public class Solution0756_2 : Interface0756
    {
        /// <summary>
        /// 回溯
        /// 假定bottom.Length = 4，按照r[2,0] -> r[2,1] -> r[1,0] -> r[2,2] -> r[1,1] -> r[0,0]的顺序尝试并回溯即可
        /// 
        /// 还是回溯简单，代码简单，跑起来也挺快的
        /// </summary>
        /// <param name="bottom"></param>
        /// <param name="allowed"></param>
        /// <returns></returns>
        public bool PyramidTransition(string bottom, IList<string> allowed)
        {
            List<int>[,] map = new List<int>[6, 6];
            for (int i = 0, r, c, t; i < allowed.Count; i++)
            {
                r = allowed[i][0] - 'A'; c = allowed[i][1] - 'A'; t = allowed[i][2] - 'A';
                if (map[r, c] == null) map[r, c] = [t]; else map[r, c].Add(t);
            }

            int n = bottom.Length;
            int[,] solution = new int[n, n];
            for (int i = 0; i < n; i++) for (int j = 0; j < n; j++) solution[i, j] = -1;
            for (int i = 0; i < n; i++) solution[n - 1, i] = bottom[i] - 'A';

            return backtrack(n - 2, 0);  // return solution[0, 0] != -1;

            bool backtrack(int r, int c)
            {
                if (r < 0) return true;
                int x = solution[r + 1, c], y = solution[r + 1, c + 1];
                if (map[x, y] == null) return false;

                bool result = false;
                foreach (int t in map[x, y])
                {
                    solution[r, c] = t;
                    result = c < r ? backtrack(r, c + 1) : backtrack(r - 1, 0);
                    if (result) return true;
                }
                return false;
            }
        }
    }
}
