using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2455
{
    public class Solution2455_api : Interface2455
    {
        public int AverageValue(int[] nums)
        {
            var query = nums.Where(num => (num & 1) != 1 && num % 3 == 0);
            return query.Count() != 0 ? query.Sum() / query.Count() : 0;
        }
    }
}
