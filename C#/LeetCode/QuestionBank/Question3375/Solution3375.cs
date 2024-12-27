using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3375
{
    public class Solution3375 : Interface3375
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinOperations(int[] nums, int k)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (int num in nums)
            {
                if (num < k) return -1;
                if (num > k) set.Add(num);
            }

            return set.Count;
        }
    }
}
