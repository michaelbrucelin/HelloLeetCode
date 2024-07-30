using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3232
{
    public class Solution3232_api : Interface3232
    {
        public bool CanAliceWin(int[] nums)
        {
            return nums.Where(x => x < 10).Sum() != nums.Where(x => x >= 10).Sum();
        }
    }
}
