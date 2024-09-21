using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3280
{
    public class Solution3280_api : Interface3280
    {
        public string ConvertDateToBinary(string date)
        {
            return $"{Convert.ToString(int.Parse(date[0..4]), 2)}-{Convert.ToString(int.Parse(date[5..7]), 2)}-{Convert.ToString(int.Parse(date[8..10]), 2)}";
        }
    }
}
