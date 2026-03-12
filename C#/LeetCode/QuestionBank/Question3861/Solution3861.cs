using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3861
{
    public class Solution3861 : Interface3861
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="itemSize"></param>
        /// <returns></returns>
        public int MinimumIndex(int[] capacity, int itemSize)
        {
            int result = -1, max = int.MaxValue, len = capacity.Length;
            for (int i = 0, num; i < len; i++) if ((num = capacity[i]) >= itemSize && num < max)
                {
                    result = i; max = num;
                }

            return result;
        }
    }
}
