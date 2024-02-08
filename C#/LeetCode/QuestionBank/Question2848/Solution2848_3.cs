using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2848
{
    public class Solution2848_3 : Interface2848
    {
        /// <summary>
        /// 差分数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int NumberOfPoints(IList<IList<int>> nums)
        {
            int[] diff = new int[102];
            foreach (var arr in nums)
            {
                diff[arr[0]]++; diff[arr[1] + 1]--;
            }

            for (int i = 1; i < 101; i++) diff[i] += diff[i - 1];

            int result = 0;
            for (int i = 1; i < 101; i++) if (diff[i] > 0) result++;

            return result;
        }
    }
}
