using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1630
{
    public class Solution1630_2 : Interface1630
    {
        /// <summary>
        /// 用整体排序来加速局部排序
        /// 具体见Solution1630_2.md
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
        {
            int len = nums.Length;
            int[] _order = new int[len], order = new int[len];
            for (int i = 0; i < len; i++) _order[i] = i;
            Array.Sort(_order, (i1, i2) => nums[i1] - nums[i2]);
            for (int i = 0; i < len; i++) order[_order[i]] = i;

            len = l.Length; const int nan = int.MinValue;
            bool[] result = new bool[len];
            int[] buckets = new int[500];
            for (int i = 0; i < len; i++)
            {
                if (l[i] + 1 >= r[i]) { result[i] = true; continue; }
                Array.Fill(buckets, nan);
                for (int j = l[i]; j <= r[i]; j++) buckets[order[j]] = nums[j];
                for (int j = 0, diff = nan, num1 = nan, num2 = nan; j < 500; j++)
                {
                    if (buckets[j] == nan) continue;
                    if (num2 == nan)
                    {
                        num2 = buckets[j];
                    }
                    else if (num1 == nan)
                    {
                        num1 = num2; num2 = buckets[j]; diff = num2 - num1;
                    }
                    else
                    {
                        num1 = num2; num2 = buckets[j]; if (num2 - num1 != diff) goto False;
                    }
                }
                result[i] = true; continue;
                False:;
            }

            return result;
        }
    }
}
