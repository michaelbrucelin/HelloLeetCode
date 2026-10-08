using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2910
{
    public class Solution2910_err2 : Interface2910
    {
        /// <summary>
        /// 贪心
        /// 
        /// 思路依然是错的，这样控制不了余数，即最小的数量
        /// </summary>
        /// <param name="balls"></param>
        /// <returns></returns>
        public int MinGroupsForValidAssignment(int[] balls)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            for (int i = 0, ball, len = balls.Length; i < len; i++)
                if (freq.TryGetValue(ball = balls[i], out int cnt)) freq[ball] = ++cnt; else freq.Add(ball, 1);
            int min = balls.Length;
            foreach (int cnt in freq.Values) min = Math.Min(min, cnt);

            int result = 0;
            foreach (int cnt in freq.Values)
                if (cnt == min) result++; else result += (cnt + min) / (min + 1);

            return result;
        }
    }
}
