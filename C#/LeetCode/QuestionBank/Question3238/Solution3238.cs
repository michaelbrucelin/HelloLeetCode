using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3238
{
    public class Solution3238 : Interface3238
    {
        public int WinningPlayerCount(int n, int[][] pick)
        {
            int[,] cnts = new int[n, 11];
            foreach (int[] p in pick) cnts[p[0], p[1]]++;

            int result = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 11; j++) if (cnts[i, j] > i)
                    {
                        result++; break;
                    }
            }

            return result;
        }
    }
}
