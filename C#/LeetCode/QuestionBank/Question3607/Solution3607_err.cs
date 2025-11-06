using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3607
{
    public class Solution3607_err : Interface3607
    {
        /// <summary>
        /// 并查集 + Hash
        /// 
        /// 思路错了，如果一个分组的id最小值down，需要找次小的，而不是返回-1
        /// </summary>
        /// <param name="c"></param>
        /// <param name="connections"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] ProcessQueries(int c, int[][] connections, int[][] queries)
        {
            bool[] up = new bool[c + 1];
            int[] uf = new int[c + 1];
            for (int i = 1; i <= c; i++) { up[i] = true; uf[i] = i; }
            foreach (int[] conn in connections) union(conn[0], conn[1]);

            List<int> result = new List<int>();
            foreach (int[] query in queries)
            {
                if (query[0] == 2)
                {
                    up[query[1]] = false;
                }
                else
                {
                    if (up[query[1]])
                    {
                        result.Add(query[1]);
                    }
                    else
                    {
                        result.Add(find(query[1]));
                        if (!up[result[^1]]) result[^1] = -1;  // 这里是错误的，如果id最小的down，需要id次小的
                    }
                }
            }

            return result.ToArray();

            void union(int x, int y)
            {
                switch (x - y)
                {
                    case < 0: uf[y] = uf[x]; break;
                    case > 0: uf[x] = uf[y]; break;
                    default: break;
                }
            }

            int find(int x)
            {
                if (uf[x] == x) return x;

                int father = find(uf[x]);
                uf[x] = father;

                return father;
            }
        }
    }
}
