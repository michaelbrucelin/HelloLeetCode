using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2195
{
    public class Solution2195 : Interface2195
    {
        /// <summary>
        /// 贪心
        /// 假定添加的就是[1, k]，然后检查nums中的值，如果在[1, k]内部，就移除这个值，增加k+1
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MinimalKSum(int[] nums, int k)
        {
            long result = (1L + k) * k >> 1;
            HashSet<int> set = new HashSet<int>();
            foreach (int num in nums) if (set.Add(num))
                {
                    if (num <= k)
                    {
                        result -= num;
                        while (set.Contains(++k)) ;
                        result += k;
                    }
                }

            return result;
        }
    }
}
