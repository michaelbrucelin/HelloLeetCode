using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2910
{
    public class Solution2910 : Interface2910
    {
        /// <summary>
        /// 暴力查找
        /// 
        /// 没写完，以后再写
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

            int result = balls.Length, _result;
            for (int k = 1; k <= min; k++)       // 选择 k 与 k+1
            {
                _result = 0;
                foreach (int cnt in freq.Values)
                {
                    
                }
                result = Math.Min(result, _result);
            }

            return result;
        }
    }
}
