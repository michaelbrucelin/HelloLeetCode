using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1281
{
    public class Solution1281_api : Interface1281
    {
        public int SubtractProductAndSum(int n)
        {
            var digits = n.ToString().Select(c => c - '0');
            return digits.Aggregate((i, j) => i * j) - digits.Sum();
        }
    }
}
