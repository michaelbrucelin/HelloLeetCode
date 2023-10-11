using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2512
{
    public class Solution2512_2 : Interface2512
    {
        /// <summary>
        /// 同Solution2512，将排序改为优先级队列，这样当k较小时，有更好的时间复杂度
        /// 最好使用TopK算法，.Net没有内置的TopK算法，暂时也懒得写了
        /// </summary>
        /// <param name="positive_feedback"></param>
        /// <param name="negative_feedback"></param>
        /// <param name="report"></param>
        /// <param name="student_id"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<int> TopStudents(string[] positive_feedback, string[] negative_feedback, string[] report, int[] student_id, int k)
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

            PriorityQueue<int, int> seq = new PriorityQueue<int, int>(Comparer<int>.Create((i, j) => point[i] - point[j] != 0 ? point[j] - point[i] : student_id[i] - student_id[j]));
            for (int i = 0; i < len; i++) seq.Enqueue(i, i);

            int[] result = new int[k];
            for (int i = 0; i < k; i++) result[i] = student_id[seq.Dequeue()];
            return result;
        }
    }
}
