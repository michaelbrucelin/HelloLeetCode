using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2931
{
    public class Solution2931_4 : Interface2931
    {
        /// <summary>
        /// 贪心 + N指针 + 小顶堆
        /// 逻辑同Solution2931，充分利用每一个子数组的有序性
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public long MaxSpending(int[][] values)
        {
            PriorityQueue<(int, int), int> minpq = new PriorityQueue<(int, int), int>();  // (int, int): (values_id, values[i]_id)
            int rcnt = values.Length, ccnt = values[0].Length;
            for (int i = 0; i < rcnt; i++) minpq.Enqueue((i, ccnt - 1), values[i][ccnt - 1]);

            long result = 0, cnt = rcnt * ccnt;
            (int id1, int id2) item;
            for (long i = 1; i <= cnt; i++)
            {
                item = minpq.Dequeue();
                result += i * values[item.id1][item.id2];
                if (item.id2 > 0) minpq.Enqueue((item.id1, item.id2 - 1), values[item.id1][item.id2 - 1]);
            }

            return result;
        }
    }
}
