using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2678
{
    public class Solution2678 : Interface2678
    {
        public int CountSeniors(string[] details)
        {
            int result = 0;
            foreach (string str in details)
                if ((str[11] - '0') * 10 + (str[12] - '0') > 60) result++;

            return result;
        }
    }
}
