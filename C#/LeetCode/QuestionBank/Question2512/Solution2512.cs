using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2512
{
    public class Solution2512 : Interface2512
    {
        /// <summary>
        /// 简单的数据处理
        /// </summary>
        /// <param name="positive_feedback"></param>
        /// <param name="negative_feedback"></param>
        /// <param name="report"></param>
        /// <param name="student_id"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<int> TopStudents(string[] positive_feedback, string[] negative_feedback, string[] report, int[] student_id, int k)
        {
            HashSet<string> positive = new HashSet<string>(positive_feedback);
            HashSet<string> negative = new HashSet<string>(negative_feedback);

            int len = report.Length;
            int[] point = new int[len];
            for (int i = 0; i < len; i++) foreach (string word in report[i].Split(' ', StringSplitOptions.RemoveEmptyEntries))
                {
                    if (positive.Contains(word)) point[i] += 3; else if (negative.Contains(word)) point[i] -= 1;
                }

            int[] seq = new int[len];
            for (int i = 0; i < len; i++) seq[i] = i;
            Array.Sort(seq, (i, j) => point[i] - point[j] != 0 ? point[j] - point[i] : student_id[i] - student_id[j]);

            int[] result = new int[k];
            for (int i = 0; i < k; i++) result[i] = student_id[seq[i]];
            return result;
        }

        /// <summary>
        /// 与TopStudents()一样，将两个hash改为一个hash
        /// </summary>
        /// <param name="positive_feedback"></param>
        /// <param name="negative_feedback"></param>
        /// <param name="report"></param>
        /// <param name="student_id"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<int> TopStudents2(string[] positive_feedback, string[] negative_feedback, string[] report, int[] student_id, int k)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            for (int i = 0; i < positive_feedback.Length; i++) if (!map.ContainsKey(positive_feedback[i])) map.Add(positive_feedback[i], 3);
            for (int i = 0; i < negative_feedback.Length; i++) if (!map.ContainsKey(negative_feedback[i])) map.Add(negative_feedback[i], -1);

            int len = report.Length;
            int[] point = new int[len];
            for (int i = 0; i < len; i++) foreach (string word in report[i].Split(' ', StringSplitOptions.RemoveEmptyEntries))
                {
                    if (map.ContainsKey(word)) point[i] += map[word];
                }

            int[] seq = new int[len];
            for (int i = 0; i < len; i++) seq[i] = i;
            Array.Sort(seq, (i, j) => point[i] - point[j] != 0 ? point[j] - point[i] : student_id[i] - student_id[j]);

            int[] result = new int[k];
            for (int i = 0; i < k; i++) result[i] = student_id[seq[i]];
            return result;
        }
    }
}
