using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2931
{
    public class Solution2931_2 : Interface2931
    {
        /// <summary>
        /// 逻辑同Solution2931，这里不使用排序，使用小顶堆
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public long MaxSpending(int[][] values)
        {
            int rcnt = values.Length, cccnt = values[0].Length;
            PriorityQueue<int, int> minpq = new PriorityQueue<int, int>();
            for (int i = 0; i < rcnt; i++) for (int j = 0; j < cccnt; j++) minpq.Enqueue(values[i][j], values[i][j]);

            long result = 0, day = 1;
            while (minpq.Count > 0) result += minpq.Dequeue() * day++;
            return result;
        }
    }
}
