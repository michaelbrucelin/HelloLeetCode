using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1512
{
    public class Solution1512_api : Interface1512
    {
        public int NumIdenticalPairs(int[] nums)
        {
            return nums.SelectMany((num1, id1) => nums.Select((num2, id2) => id1 < id2 && num1 == num2)).Count(b => b);
        }
    }
}
