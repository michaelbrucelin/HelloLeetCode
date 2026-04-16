using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2076
{
    public class Solution2076_2 : Interface2076
    {
        /// <summary>
        /// 并查集
        /// Solution2076中想多了，不需要回退并查集，多查1次就可以了
        /// </summary>
        /// <param name="n"></param>
        /// <param name="restrictions"></param>
        /// <param name="requests"></param>
        /// <returns></returns>
        public bool[] FriendRequests(int n, int[][] restrictions, int[][] requests)
        {
            int len = requests.Length;
            int[] uf = new int[n], rank = new int[n];
            for (int i = 0; i < n; i++) uf[i] = i;
            bool[] result = new bool[len];
            for (int i = 0; i < len; i++) result[i] = union(requests[i][0], requests[i][1]);

            return result;

            int find(int x)
            {
                if (uf[x] != x) uf[x] = find(uf[x]);
                return uf[x];
            }

            bool union(int x, int y)
            {
                x = find(x); y = find(y);
                if (x == y) return true;

                int u, v;
                foreach (int[] check in restrictions)
                {
                    u = find(check[0]); v = find(check[1]);
                    if ((u == x && v == y) || (u == y && v == x)) return false;
                }

                switch (rank[x] - rank[y])
                {
                    case > 0: uf[y] = x; break;
                    case < 0: uf[x] = y; break;
                    default: uf[y] = x; rank[x]++; break;
                }

                return true;
            }
        }
    }
}
