using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0781
{
    public class Solution0781 : Interface0781
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="answers"></param>
        /// <returns></returns>
        public int NumRabbits(int[] answers)
        {
            int result = 0, len = answers.Length;
            int[] capacity = new int[1000];
            for (int i = 0, ans; i < len; i++)
            {
                ans = answers[i];
                if (capacity[ans] > 0)
                {
                    capacity[ans]--;
                }
                else
                {
                    capacity[ans] = ans;
                    result += ans + 1;
                }
            }

            return result;
        }
    }
}
