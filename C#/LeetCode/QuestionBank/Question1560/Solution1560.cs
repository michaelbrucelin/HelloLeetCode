using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1560
{
    public class Solution1560 : Interface1560
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <param name="rounds"></param>
        /// <returns></returns>
        public IList<int> MostVisited(int n, int[] rounds)
        {
            int[] cnts = new int[n + 1];
            cnts[rounds[0]] = 1;
            for (int i = 1, start = 0, end = 0; i < rounds.Length; i++)
            {
                start = rounds[i - 1] + 1; end = rounds[i];  // 题目限定rounds[i] != rounds[i + 1]
                if (end >= start)
                {
                    for (int j = start; j <= end; j++) cnts[j]++;
                }
                else
                {
                    for (int j = start; j <= n; j++) cnts[j]++;
                    for (int j = 1; j <= end; j++) cnts[j]++;
                }
            }

            int max = cnts[1];
            for (int i = 2; i <= n; i++) max = Math.Max(max, cnts[i]);

            List<int> result = new List<int>();
            for (int i = 1; i <= n; i++) if (cnts[i] == max) result.Add(i);
            return result;
        }
    }
}
