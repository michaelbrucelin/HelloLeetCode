using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1817
{
    public class Solution1817 : Interface1817
    {
        public int[] FindingUsersActiveMinutes(int[][] logs, int k)
        {
            Dictionary<int, HashSet<int>> buffer = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < logs.Length; i++)
            {
                if (buffer.ContainsKey(logs[i][0]))
                    buffer[logs[i][0]].Add(logs[i][1]);
                else
                    buffer.Add(logs[i][0], new HashSet<int>() { logs[i][1] });
            }

            int[] result = new int[k];
            foreach (var kv in buffer)
            {
                int minutes = kv.Value.Count;
                if (minutes <= k) result[minutes - 1]++;
            }

            return result;
        }

        /// <summary>
        /// 与FindingUsersActiveMinutes()一样，使用Linq
        /// </summary>
        /// <param name="logs"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] FindingUsersActiveMinutes2(int[][] logs, int k)
        {
            var query = logs.GroupBy(arr => arr[0])
                            .Select(g => new { id = g.Key, minutes = g.Select(arr => arr[1]).Distinct().Count() })
                            .GroupBy(item => item.minutes)
                            .Select(g => new { minutes = g.Key, count = g.Count() });

            int[] result = new int[k];
            foreach (var item in query)
                if (item.minutes <= k) result[item.minutes - 1] = item.count;

            return result;
        }
    }
}
