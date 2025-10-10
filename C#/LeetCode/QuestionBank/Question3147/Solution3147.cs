using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3147
{
    public class Solution3147 : Interface3147
    {
        /// <summary>
        /// 贪心
        /// 从后向前k轮循环即可
        /// </summary>
        /// <param name="energy"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaximumEnergy(int[] energy, int k)
        {
            int result = energy[^1], len = energy.Length;
            for (int _k = 1, _result; _k <= k; _k++)
            {
                _result = 0;
                for (int i = len - _k; i >= 0; i -= k)
                {
                    _result += energy[i];
                    result = Math.Max(result, _result);
                }
            }

            return result;
        }
    }
}
