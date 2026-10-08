using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2910
{
    public class Solution2910_err : Interface2910
    {
        /// <summary>
        /// 贪心
        /// 最少的一定不拆分，数量从小到大逐一分析
        /// 
        /// 都错题了，题目要求的是最大和最小相差不超过1，这里做的是相邻的相差不超过1
        /// 题目的通过率这么低，难不成都读错题了... ...
        /// </summary>
        /// <param name="balls"></param>
        /// <returns></returns>
        public int MinGroupsForValidAssignment(int[] balls)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            for (int i = 0, ball, len = balls.Length; i < len; i++)
                if (freq.TryGetValue(ball = balls[i], out int cnt)) freq[ball] = ++cnt; else freq.Add(ball, 1);
            int[] cnts = new int[freq.Count];
            int id = 0;
            foreach (int cnt in freq.Values) cnts[id++] = cnt;
            Array.Sort(cnts);

            int result = 0, last = cnts[0];
            for (int i = 0, cnt, len = cnts.Length; i < len; i++)
            {
                if ((cnt = cnts[i]) <= last + 1)
                {
                    result++;
                }
                else
                {
                    result += (cnt + last) / (last + 1);
                    last++;
                }
            }

            return result;
        }
    }
}
