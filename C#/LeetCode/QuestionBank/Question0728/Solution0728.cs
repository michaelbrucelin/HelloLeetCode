using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0728
{
    public class Solution0728 : Interface0728
    {
        public IList<int> SelfDividingNumbers(int left, int right)
        {
            List<int> result = new List<int>();
            for (int i = left; i <= right; i++) if (IsSelfDividingNumber(i)) result.Add(i);

            return result;
        }

        private bool IsSelfDividingNumber(int num)
        {
            int _num = num;
            while (_num > 0)  // 题目保证了num >= 1
            {
                var info = Math.DivRem(_num, 10);
                if (info.Remainder == 0 || num % info.Remainder != 0) return false;
                _num = info.Quotient;
            }

            return true;
        }

        public IList<int> SelfDividingNumbers2(int left, int right)
        {
            return Enumerable.Range(left, right - left + 1)
                             .Where(i => i.ToString().All(c => c != '0' && i % (c - '0') == 0))
                             .ToArray();
        }
    }
}
