using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0374
{
    public class Solution0374 : GuessGame, Interface0374
    {
        public int GuessNumber(int n)
        {
            int low = 1, high = n, mid, r;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                r = guess(mid);
                if (r == 0)
                    return mid;
                else if (r > 0)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return -1;
        }
    }
}
