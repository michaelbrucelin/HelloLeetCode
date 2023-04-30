using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0050
{
    public class Solution0050 : Interface0050
    {
        public int GiveGem(int[] gem, int[][] operations)
        {
            for (int i = 0; i < operations.Length; i++)
            {
                int give = gem[operations[i][0]] >> 1;
                gem[operations[i][0]] -= give;
                gem[operations[i][1]] += give;
            }

            int max = gem[0], min = gem[0];
            for (int i = 0; i < gem.Length; i++)
            {
                if (gem[i] > max) max = gem[i]; else if (gem[i] < min) min = gem[i];
            }

            return max - min;
        }
    }
}
