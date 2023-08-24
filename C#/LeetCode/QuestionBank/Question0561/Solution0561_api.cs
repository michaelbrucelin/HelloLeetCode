using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0561
{
    public class Solution0561_api : Interface0561
    {
        public int ArrayPairSum(int[] nums)
        {
            return nums.OrderBy(i => i).Where((num, id) => (id & 1) != 1).Sum();
        }
    }
}
