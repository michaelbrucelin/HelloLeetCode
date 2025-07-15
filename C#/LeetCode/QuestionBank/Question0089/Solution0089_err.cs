using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0089
{
    public class Solution0089_err : Interface0089
    {
        /// <summary>
        /// 构造
        /// 枚举n = 2, 3, 4很容易找规律
        /// 例如，n = 4
        /// x个1  0  1  2  3  4
        /// 数量  1  4  6  4  1
        /// 顺序  0 1 2 3 4    3 2 3 2 3    2 1 2 1 2 1    1
        /// 
        /// 题目要求的是相邻两个值的二进制表示只有1位不同，而这里给出的解是相邻两个值的二进制表示1的数量相差1，题目理解错了
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<int> GrayCode(int n)
        {
            if (n == 1) return [0, 1];

            List<int> result = new List<int>();
            Queue<int>[] dist = new Queue<int>[n + 1];
            for (int i = 0; i <= n; i++) dist[i] = new Queue<int>();
            int limit = 1 << n;
            for (int i = 0; i < limit; i++) dist[bitcnt(i)].Enqueue(i);

            // 构造
            for (int i = 0; i <= n; i++) result.Add(dist[i].Dequeue());
            int p = n;
            while (--p > 1)
            {
                while (dist[p].Count > 0) { result.Add(dist[p].Dequeue()); result.Add(dist[p - 1].Dequeue()); }
            }
            if (dist[1].Count > 0) result.Add(dist[1].Dequeue());

            return result;

            int bitcnt(int x)
            {
                int cnt = 0;
                while (x > 0) { cnt++; x &= x - 1; }
                return cnt;
            }
        }
    }
}
