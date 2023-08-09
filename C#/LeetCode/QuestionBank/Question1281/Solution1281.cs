using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1281
{
    public class Solution1281 : Interface1281
    {
        public int SubtractProductAndSum(int n)
        {
            int pro = 1, sum = 0, _n;
            while (n > 0)
            {
                _n = n % 10;
                pro *= _n; sum += _n;
                n /= 10;
            }

            return pro - sum;
        }
    }
}
