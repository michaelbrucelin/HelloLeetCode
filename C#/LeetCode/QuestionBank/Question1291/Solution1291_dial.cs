using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1291
{
    public class Solution1291_dial : Interface1291
    {
        private static readonly int[] sdigits = [12, 23, 34, 45, 56, 67, 78, 89, 123, 234, 345, 456, 567, 678, 789, 1234, 2345, 3456, 4567, 5678, 6789,12345, 23456,
                                                 34567, 45678, 56789, 123456, 234567, 345678, 456789, 1234567, 2345678, 3456789, 12345678, 23456789, 123456789];

        public IList<int> SequentialDigits(int low, int high)
        {
            List<int> result = [];
            for (int i = 0; i < 36 && sdigits[i] <= high; i++) if (sdigits[i] >= low) result.Add(sdigits[i]);

            return result;
        }
    }
}
