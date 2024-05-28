using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3158
{
    public class Solution3158_api : Interface3158
    {
        public int DuplicateNumbersXOR(int[] nums)
        {
            return nums.GroupBy(x => x).Where(g => g.Count() == 2).Select(g => g.Key).Aggregate(0, (x, y) => x ^ y);
        }
    }
}
