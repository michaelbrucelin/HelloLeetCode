using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2931
{
    public class Solution2931 : Interface2931
    {
        /// <summary>
        /// 贪心
        /// 价格越贵的越应该晚买，所以排序即可（计数排序）
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public long MaxSpending(int[][] values)
        {
            int min;
            int[] sort = CountingSort(out min);
            long result = 0;
            int len = sort.Length;
            for (int i = 0, day = 1; i < len; i++) for (int j = 0, price = i + min; j < sort[i]; j++)
                {
                    result += (long)price * day++;
                }

            return result;

            int[] CountingSort(out int min)
            {
                int rcnt = values.Length, ccnt = values[0].Length, max = values[0][0]; min = values[0][0];
                for (int i = 0; i < rcnt; i++) for (int j = 0; j < ccnt; j++)
                    {
                        min = Math.Min(min, values[i][j]); max = Math.Max(max, values[i][j]);
                    }

                int[] counter = new int[max - min + 1];
                for (int i = 0; i < rcnt; i++) for (int j = 0; j < ccnt; j++) counter[values[i][j] - min]++;

                return counter;
            }
        }
    }
}
