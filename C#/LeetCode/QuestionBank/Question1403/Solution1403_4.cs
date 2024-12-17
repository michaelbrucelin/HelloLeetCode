using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1403
{
    public class Solution1403_4 : Interface1403
    {
        /// <summary>
        /// 计数排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> MinSubsequence(int[] nums)
        {
            int[] freq = new int[101];
            int target = 0, sum = 0, len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                target += nums[i];
                freq[nums[i]]++;
            }

            List<int> result = new List<int>();
            target >>= 1;
            for (int i = 100; i > 0; i--) for (int j = 0; j < freq[i]; j++)
                {
                    result.Add(i);
                    if ((sum += i) > target) goto END;
                }
            END:;

            return result;
        }
    }
}
