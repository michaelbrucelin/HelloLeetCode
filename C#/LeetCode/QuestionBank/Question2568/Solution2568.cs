using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2568
{
    public class Solution2568 : Interface2568
    {
        /// <summary>
        /// 脑筋急转弯
        /// 结果一定是2的幂，即其二进制表达式中只有1个1，反证法很容易证明
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinImpossibleOR(int[] nums)
        {
            int result = 1;
            HashSet<int> set = [.. nums];
            while (set.Contains(result)) result <<= 1;

            return result;
        }
    }
}
