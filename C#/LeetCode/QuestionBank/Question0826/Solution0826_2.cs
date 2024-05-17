using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0826
{
    public class Solution0826_2 : Interface0826
    {
        /// <summary>
        /// 排序 + 双指针
        /// 逻辑同Solution0826，只是将其中的二分改为了 排序worker数组 + 双指针
        /// </summary>
        /// <param name="difficulty"></param>
        /// <param name="profit"></param>
        /// <param name="worker"></param>
        /// <returns></returns>
        public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
        {
            int len = difficulty.Length;
            int[] index = new int[len];
            for (int i = 0; i < len; i++) index[i] = i;
            Array.Sort(index, (i, j) => difficulty[i] - difficulty[j]);
            for (int i = 1; i < len; i++) profit[index[i]] = Math.Max(profit[index[i]], profit[index[i - 1]]);
            Array.Sort(worker);

            int result = 0;
            for (int i = 0, j = -1; i < worker.Length; i++)
            {
                while (j + 1 < len && difficulty[index[j + 1]] <= worker[i]) j++;
                if (j > -1) result += profit[index[j]];
            }

            return result;
        }
    }
}
