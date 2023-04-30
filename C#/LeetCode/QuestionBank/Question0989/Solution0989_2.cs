using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0989
{
    public class Solution0989_2 : Interface0989
    {
        public IList<int> AddToArrayForm(int[] num, int k)
        {
            List<int> result = new List<int>();
            for (int i = num.Length - 1; i >= 0 || k > 0; i--)
            {
                if (i >= 0) k += num[i];
                var info = Math.DivRem(k, 10);
                result.Add(info.Remainder);
                k = info.Quotient;
            }

            result.Reverse();
            return result;
        }
    }
}
