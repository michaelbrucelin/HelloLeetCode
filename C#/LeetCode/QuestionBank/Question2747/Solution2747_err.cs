using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2747
{
    public class Solution2747_err : Interface2747
    {
        /// <summary>
        /// 稀疏表
        /// 首先找到时间的最大值maxtime，声明一个长度为maxtime+1的数组，数组的每一项为n，表示此刻有n个服务器没有收到信号
        /// 然后使用稀疏表实现快速查出数组区间的最大值
        /// 
        /// 题目理解错了，题目要的是区间内没有收到日志的服务器的数量，这里求的是区间内某一时刻没有收到服务器日志的数量的最大值
        /// </summary>
        /// <param name="n"></param>
        /// <param name="logs"></param>
        /// <param name="x"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] CountServers(int n, int[][] logs, int x, int[] queries)
        {
            int maxtime = 0, len = queries.Length;
            for (int i = 0; i < len; i++) maxtime = Math.Max(maxtime, queries[i]);
            int[] cnts = new int[maxtime + 1];
            Array.Fill(cnts, n);
            HashSet<(int, int)> set = [];
            foreach (int[] log in logs) if (log[1] <= maxtime && set.Add((log[0], log[1]))) cnts[log[1]]--;

            int[] result = new int[len];
            SparseTable st = new SparseTable(cnts);
            for (int i = 0; i < len; i++) result[i] = st.Search(queries[i] - x, queries[i]);

            return result;
        }

        public class SparseTable
        {
            public SparseTable(int[] arr)
            {
                length = arr.Length;
                st = [[.. arr]];
                build();
            }

            private readonly List<int[]> st;
            private readonly int length;

            private void build()
            {
                int span = 2, id = 0, len;
                while (span <= length)
                {
                    st.Add(new int[len = length - span + 1]);
                    id++;
                    for (int i = 0, j = span >> 1; i < len; i++, j++) st[id][i] = Math.Max(st[id - 1][i], st[id - 1][j]);
                    span <<= 1;
                }
            }

            public int Search(int lo, int hi)
            {
                if (lo < 0) lo = 0;
                if (hi >= length) hi = length - 1;

                int id = 0, span = 1, len = hi - lo + 1;
                while ((span << 1) < len) { id++; span <<= 1; }
                return Math.Max(st[id][lo], st[id][hi - span + 1]);
            }
        }
    }
}
