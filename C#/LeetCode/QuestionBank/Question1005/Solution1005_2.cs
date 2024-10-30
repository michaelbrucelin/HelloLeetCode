using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1005
{
    public class Solution1005_2 : Interface1005
    {
        /// <summary>
        /// 逻辑同Solution1005，排序改为基数排序
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int LargestSumAfterKNegations(int[] nums, int k)
        {
            int[] freq = new int[201];
            for (int i = 0; i < nums.Length; i++)
            {
                freq[nums[i] + 100]++;
            }

            int sum = 0, min = 101;
            // 负数部分
            for (int i = 0; i < 100; i++) if (freq[i] > 0)
                {
                    min = Math.Min(min, 100 - i);
                    if (k > 0)
                    {
                        if (k >= freq[i])
                        {
                            sum -= (i - 100) * freq[i];
                            k -= freq[i];
                        }
                        else
                        {
                            sum -= (i - 100) * k;
                            sum += (i - 100) * (freq[i] - k);
                            k = 0;
                        }
                    }
                    else
                    {
                        sum += (i - 100) * freq[i];
                    }
                }
            // 正数部分
            for (int i = 101; i < 201; i++) if (freq[i] > 0)
                {
                    min = Math.Min(min, i - 100);
                    sum += (i - 100) * freq[i];
                }
            // 特殊处理
            if (freq[100] == 0 && (k & 1) == 1) sum -= min << 1;

            return sum;
        }
    }
}
