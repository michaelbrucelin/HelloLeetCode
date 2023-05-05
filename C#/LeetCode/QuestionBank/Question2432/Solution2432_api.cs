using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2432
{
    public class Solution2432_api : Interface2432
    {
        public int HardestWorker(int n, int[][] logs)
        {
            if (logs.Length == 1) return logs[0][0];

            return logs.Select((i, id) => id == 0 ? (i[0], i[1]) : (i[0], i[1] - logs[id - 1][1]))
                       .OrderByDescending(item => item.Item2)
                       .ThenBy(item => item.Item1)
                       .First().Item1;
        }

        public int HardestWorker2(int n, int[][] logs)
        {
            if (logs.Length == 1) return logs[0][0];

            var comparer = Comparer<(int, int)>.Create((item1, item2) => item1.Item2 != item2.Item2 ? item1.Item2 - item2.Item2 : item2.Item1 - item1.Item1);

            return logs.Select((i, id) => id == 0 ? (i[0], i[1]) : (i[0], i[1] - logs[id - 1][1]))
                       .Max(comparer).Item1;
        }
    }
}
