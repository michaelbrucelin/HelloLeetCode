using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0001
{
    public class Solution0001 : Interface0001
    {
        public int game(int[] guess, int[] answer)
        {
            int result = 0;
            if (guess[0] == answer[0]) result++;
            if (guess[1] == answer[1]) result++;
            if (guess[2] == answer[2]) result++;

            return result;
        }
    }
}
