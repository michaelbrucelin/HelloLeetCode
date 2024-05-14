using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2244
{
    public class Solution2244 : Interface2244
    {
        /// <summary>
        /// 计数
        /// N=1    个任务，无法完成
        /// N=3k   个任务，k 轮完成                          (N+2)/3
        /// N=3k+1 个任务，即 3(k-1) + 4 个任务，k+1 轮完成  (N+2)/3
        /// N=3k+2 个任务，k+1 轮完成                        (N+2)/3
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public int MinimumRounds(int[] tasks)
        {
            Dictionary<int, int> freqs = new Dictionary<int, int>();
            foreach (int task in tasks)
            {
                if (freqs.ContainsKey(task)) freqs[task]++; else freqs.Add(task, 1);
            }

            int result = 0;
            foreach (int freq in freqs.Values)
            {
                if (freq == 1) return -1;
                result += (freq + 2) / 3;
            }

            return result;
        }
    }
}
