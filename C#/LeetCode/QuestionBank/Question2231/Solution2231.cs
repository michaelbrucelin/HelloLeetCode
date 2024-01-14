using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2231
{
    public class Solution2231 : Interface2231
    {
        public int LargestInteger(int num)
        {
            int[] freq = new int[10];
            Stack<bool> stack = new Stack<bool>();  // true 奇数, false 偶数
            int r;
            while (num > 0)
            {
                r = num % 10;
                freq[r]++;
                stack.Push((r & 1) != 0);
                num /= 10;
            }

            int result = 0, p1 = 9, p2 = 8;
            while (stack.Count > 0)
            {
                if (stack.Pop())
                {
                    while (freq[p1] == 0) p1 -= 2;
                    result = result * 10 + p1;
                    freq[p1]--;
                }
                else
                {
                    while (freq[p2] == 0) p2 -= 2;
                    result = result * 10 + p2;
                    freq[p2]--;
                }
            }

            return result;
        }
    }
}
