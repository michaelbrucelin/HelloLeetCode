using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0268
{
    public class Solution0268 : Interface0268
    {
        public int MissingNumber(int[] nums)
        {
            int result = 0;
            for (int i = 0; i < nums.Length; i++) result ^= nums[i] ^ (i + 1);

            return result;
        }
    }
}
