using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1491
{
    public class Solution1491 : Interface1491
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="salary"></param>
        /// <returns></returns>
        public double Average(int[] salary)
        {
            int min = salary[0], max = salary[0], sum = salary[0], len = salary.Length;
            for (int i = 1, num; i < len; i++)
            {
                min = Math.Min(min, salary[i]);
                max = Math.Max(max, salary[i]);
                sum += salary[i];
            }

            return ((double)sum - max - min) / (len - 2);
        }
    }
}
