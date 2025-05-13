using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3335
{
    public class Utils3335
    {
        public void Dial(string s, int t)
        {
            Interface3335 solution = new Solution3335();
            for (int i = 1; i <= t; i++) Console.WriteLine($"{i}\t{solution.LengthAfterTransformations(s, i)}");
        }
    }
}
