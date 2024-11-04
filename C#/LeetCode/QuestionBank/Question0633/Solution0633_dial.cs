using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0633
{
    public class Solution0633_dial : Interface0633
    {
        private static readonly int[] nums = [0, 1, 4, 9, 16, 25, 36, 49, 64, 81];  //数组太长，不写了

        public bool JudgeSquareSum(int c)
        {
            int pl = 0, pr = nums.Length - 1;
            while (pl <= pr)
            {
                if (nums[pl] == c || nums[pr] == c) return true;
                switch (nums[pl] + nums[pr] - c)
                {
                    case < 0: pl++; break;
                    case > 0: pr--; break;
                    default: return true;
                }
            }

            return false;
        }
    }
}
