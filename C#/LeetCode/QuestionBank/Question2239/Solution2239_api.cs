using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2239
{
    public class Solution2239_api : Interface2239
    {
        public int FindClosestNumber(int[] nums)
        {
            Comparer<int> comparer = Comparer<int>.Create((i, j) =>
            {
                int _i = Math.Abs(i), _j = Math.Abs(j);
                if (_i < _j) return -1;
                if (_i > _j) return 1;
                return j - i;
            });

            return nums.Min(comparer);
        }
    }
}
