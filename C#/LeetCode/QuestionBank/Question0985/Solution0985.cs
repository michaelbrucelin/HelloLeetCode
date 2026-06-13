using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0985
{
    public class Solution0985 : Interface0985
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] SumEvenAfterQueries(int[] nums, int[][] queries)
        {
            int sum = 0, len = queries.Length;
            foreach (int num in nums) sum += num * (1 - (num & 1));

            int[] result = new int[len];
            int val, idx;
            for (int i = 0; i < len; i++)
            {
                val = queries[i][0]; idx = queries[i][1];
                sum -= nums[idx] * (1 - (nums[idx] & 1));
                nums[idx] += val;
                sum += nums[idx] * (1 - (nums[idx] & 1));
                result[i] = sum;
            }

            return result;
        }
    }
}
