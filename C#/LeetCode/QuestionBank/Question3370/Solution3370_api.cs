using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3370
{
    public class Solution3370_api : Interface3370
    {
        public int SmallestNumber(int n)
        {
            return Convert.ToInt32(new string('1', Convert.ToString(n, 2).Length), 2);
        }

        public int SmallestNumber2(int n)
        {
            return (1 << (Convert.ToString(n, 2).Length)) - 1;
        }
    }
}
