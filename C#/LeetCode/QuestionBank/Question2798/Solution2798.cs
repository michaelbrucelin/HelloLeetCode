using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2798
{
    public class Solution2798 : Interface2798
    {
        public int NumberOfEmployeesWhoMetTarget(int[] hours, int target)
        {
            int result = 0;
            for (int i = 0; i < hours.Length; i++) if (hours[i] >= target) result++;

            return result;
        }
    }
}
