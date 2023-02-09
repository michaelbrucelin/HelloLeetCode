using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0412
{
    public class Solution0412 : Interface0412
    {
        public IList<string> FizzBuzz(int n)
        {
            string[] result = new string[n];
            for (int i = 0; i < n; i++) result[i] = (i + 1).ToString();
            for (int i = 2; i < n; i += 3) result[i] = "Fizz";
            for (int i = 4; i < n; i += 5) result[i] = "Buzz";
            for (int i = 14; i < n; i += 15) result[i] = "FizzBuzz";

            return result;
        }
    }
}
