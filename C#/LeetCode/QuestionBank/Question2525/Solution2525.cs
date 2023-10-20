using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2525
{
    public class Solution2525 : Interface2525
    {
        public string CategorizeBox(int length, int width, int height, int mass)
        {
            int map = 0;
            long bulk = 1;
            if (length >= 10000 || width >= 10000 || height >= 10000 || (bulk = bulk * length * width * height) >= 1000000000) map |= 1;
            if (mass >= 100) map |= 2;

            return map switch { 0 => "Neither", 1 => "Bulky", 2 => "Heavy", 3 => "Both", _ => throw new Exception("logic error") };
        }
    }
}
