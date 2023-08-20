using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1295
{
    public class Solution1295_api : Interface1295
    {
        public int FindNumbers(int[] nums)
        {
            return nums.Where(i => (i.ToString().Length & 1) != 1).Count();
        }
    }
}
