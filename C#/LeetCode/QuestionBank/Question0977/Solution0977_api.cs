using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0977
{
    public class Solution0977_api : Interface0977
    {
        public int[] SortedSquares(int[] nums)
        {
            return nums.Select(i => i * i).OrderBy(i => i).ToArray();
        }
    }
}
