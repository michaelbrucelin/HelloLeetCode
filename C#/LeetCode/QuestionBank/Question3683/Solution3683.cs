using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3683
{
    public class Solution3683 : Interface3683
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public int EarliestTime(int[][] tasks)
        {
            int result = tasks[0][0] + tasks[0][1], len = tasks.Length;
            for (int i = 1; i < len; i++) result = Math.Min(result, tasks[i][0] + tasks[i][1]);

            return result;
        }
    }
}
