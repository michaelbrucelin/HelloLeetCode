using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1819
{
    public class Solution1819_2 : Interface1819
    {
        public int CountDifferentSubsequenceGCDs(int[] nums)
        {
            HashSet<int> set = new HashSet<int>(nums);
            int maxnum = nums.Max();

            int result = 0;
            for (int x = 1; x <= maxnum; x++)
            {
                if (set.Contains(x)) result++;
                else
                {
                    int gcd = -1;
                    for (int i = x << 1; i <= maxnum; i += x)
                    {
                        if (set.Contains(i))
                        {
                            gcd = gcd == -1 ? i : GetGCD(gcd, i);
                            if (gcd == x)
                            {
                                result++; break;
                            }
                        }
                    }
                }
            }

            return result;
        }

        private int GetGCD(int x, int y)
        {
            if (x == y) return x;

            int move = 0;
            while (x != y)
            {
                if ((x & 1) == 0 && (y & 1) == 0)
                {
                    x >>= 1; y >>= 1; move++;
                }
                else if ((x & 1) == 0 && (y & 1) == 1) x >>= 1;
                else if ((x & 1) == 1 && (y & 1) == 0) y >>= 1;
                else
                {
                    if (x > y) x = (x - y) >> 1; else y = (y - x) >> 1;
                }
            }

            return x << move;
        }
    }
}
