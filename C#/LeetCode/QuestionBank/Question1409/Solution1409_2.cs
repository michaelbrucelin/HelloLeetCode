using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1409
{
    public class Solution1409_2 : Interface1409
    {
        /// <summary>
        /// 模拟
        /// 使用小顶堆模拟试一下
        /// </summary>
        /// <param name="queries"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int[] ProcessQueries(int[] queries, int m)
        {
            PriorityQueue<(int, int), int> minpq = new PriorityQueue<(int, int), int>();
            for (int i = 0; i < m; i++) minpq.Enqueue((i + 1, i), i);
            Queue<(int, int)> queue = new Queue<(int, int)>();

            int len = queries.Length;
            int[] result = new int[len];
            (int val, int idx) item;
            for (int i = 0; i < len; i++)
            {
                item = minpq.Dequeue();
                while (item.val != queries[i]) { queue.Enqueue(item); item = minpq.Dequeue(); }
                result[i] = item.idx;
                minpq.Enqueue((item.val, 0), 0);
                while (queue.Count > 0)
                {
                    item = queue.Dequeue();
                    minpq.Enqueue((item.val, item.idx + 1), item.idx + 1);
                }
            }

            return result;
        }
    }
}
