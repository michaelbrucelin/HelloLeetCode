using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2432
{
    public class Solution2432 : Interface2432
    {
        public int HardestWorker(int n, int[][] logs)
        {
            if (logs.Length == 1) return logs[0][0];

            int result = logs[0][0], time_max = logs[0][1], time_i;
            for (int i = 1; i < logs.Length; i++)
            {
                time_i = logs[i][1] - logs[i - 1][1];
                if (time_i > time_max)
                {
                    result = logs[i][0]; time_max = time_i;
                }
                else if (time_i == time_max && logs[i][0] < result)
                {
                    result = logs[i][0];
                }
            }

            return result;
        }
    }
}
