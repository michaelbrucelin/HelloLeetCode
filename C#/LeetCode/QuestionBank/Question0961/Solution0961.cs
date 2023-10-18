using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0961
{
    public class Solution0961 : Interface0961
    {
        /// <summary>
        /// 哈希
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RepeatedNTimes(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (int num in nums)
            {
                if (set.Contains(num)) return num;
                set.Add(num);
            }

            throw new Exception("logic error");
        }
    }
}
