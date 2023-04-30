using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2469
{
    public class Solution2469 : Interface2469
    {
        public double[] ConvertTemperature(double celsius)
        {
            return new double[] { celsius + 273.15D, celsius * 1.80D + 32.00D };
        }
    }
}
