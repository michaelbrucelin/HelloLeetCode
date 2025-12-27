using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2402
{
    public class Solution2402_err : Interface2402
    {
        /// <summary>
        /// 堆
        /// 逻辑错误，参考测试用例03
        /// </summary>
        /// <param name="n"></param>
        /// <param name="meetings"></param>
        /// <returns></returns>
        public int MostBooked(int n, int[][] meetings)
        {
            if (n == 1) return 0;

            Comparer<(int, int)> comparer = Comparer<(int, int)>.Create((x, y) => x.Item2 != y.Item2 ? x.Item2 - y.Item2 : x.Item1 - y.Item1);
            PriorityQueue<(int, int), (int, int)> minpq = new PriorityQueue<(int, int), (int, int)>(comparer);
            for (int i = 0; i < n; i++) minpq.Enqueue((i, 0), (i, 0));

            Array.Sort(meetings, (x, y) => x[0] - y[0]);
            int[] cnts = new int[n];
            (int id, int end) item; int _end;
            foreach (int[] meet in meetings)
            {
                item = minpq.Dequeue();
                cnts[item.id]++;
                _end = item.end <= meet[0] ? meet[1] : item.end - meet[0] + meet[1];
                minpq.Enqueue((item.id, _end), (item.id, _end));
            }

            int result = 0;
            for (int i = 1; i < n; i++) if (cnts[i] > cnts[result]) result = i;
            return result;
        }
    }
}
