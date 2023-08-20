using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2778
{
    public class Solution2778_api : Interface2778
    {
        public int SumOfSquares(int[] nums)
        {
            int len = nums.Length;
            return nums.Where((num, id) => len % (id + 1) == 0).Sum(i => i * i);
        }
    }
}
