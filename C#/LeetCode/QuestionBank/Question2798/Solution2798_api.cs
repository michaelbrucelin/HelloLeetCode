using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2798
{
    public class Solution2798_api : Interface2798
    {
        public int NumberOfEmployeesWhoMetTarget(int[] hours, int target)
        {
            return hours.Count(i => i >= target);
        }
    }
}
