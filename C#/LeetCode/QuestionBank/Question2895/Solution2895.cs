using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2895
{
    public class Solution2895 : Interface2895
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="processorTime"></param>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public int MinProcessingTime(IList<int> processorTime, IList<int> tasks)
        {
            List<int> _tasks = [.. tasks];
            _tasks.Sort();
            List<int> _proce = [.. processorTime];
            _proce.Sort();

            int result = 0;
            for (int i = _proce.Count - 1, j = 0; i >= 0; i--) for (int k = 0; k < 4; k++)
                {
                    result = Math.Max(result, _proce[i] + _tasks[j++]);
                }

            return result;
        }
    }
}
