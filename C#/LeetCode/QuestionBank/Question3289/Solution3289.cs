using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3289
{
    public class Solution3289 : Interface3289
    {
        /// <summary>
        /// hash
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] GetSneakyNumbers(int[] nums)
        {
            int[] result = new int[2];
            int id = 0, n = nums.Length;
            bool[] mask = new bool[n - 2];
            for (int i = 0, num; i < n; i++)
            {
                num = nums[i];
                if (mask[num])
                {
                    result[id++] = num;
                    if (id == 2) break;
                }
                else
                {
                    mask[num] = true;
                }
            }

            return result;
        }
    }
}
