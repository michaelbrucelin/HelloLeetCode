using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1502
{
    public class Solution1502_api : Interface1502
    {
        public bool CanMakeArithmeticProgression(int[] arr)
        {
            var sarr = arr.OrderBy(x => x).ToArray();
            return sarr.Skip(1).Zip(sarr, (i2, i1) => i2 - i1).Distinct().Count() == 1;
        }
    }
}
