using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2512
{
    public class Solution2512_api : Interface2512
    {
        public IList<int> TopStudents(string[] positive_feedback, string[] negative_feedback, string[] report, int[] student_id, int k)
        {
            Dictionary<string, int> map = new Dictionary<string, int>(
                positive_feedback.Distinct().Select(s => new KeyValuePair<string, int>(s, 3)).Concat(
                negative_feedback.Distinct().Select(s => new KeyValuePair<string, int>(s, -1)))
            );

            int[] point = report.Select(s => s.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                              .Select(w => map.ContainsKey(w) ? map[w] : 0)
                                              .Sum())
                                .ToArray();

            return Enumerable.Range(0, report.Length)
                             .OrderByDescending(i => point[i])
                             .ThenBy(i => student_id[i])
                             .Take(k)
                             .Select(i => student_id[i])
                             .ToArray();
        }
    }
}
