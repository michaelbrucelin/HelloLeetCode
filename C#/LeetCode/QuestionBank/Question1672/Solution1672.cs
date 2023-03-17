using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1672
{
    public class Solution1672 : Interface1672
    {
        public int MaximumWealth(int[][] accounts)
        {
            int result = 0;
            for (int i = 0; i < accounts.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < accounts[i].Length; j++) sum += accounts[i][j];
                result = Math.Max(result, sum);
            }

            return result;
        }
    }
}
