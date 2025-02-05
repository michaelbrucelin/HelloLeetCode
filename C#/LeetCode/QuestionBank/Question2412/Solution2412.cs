using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2412
{
    public class Solution2412 : Interface2412
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactions"></param>
        /// <returns></returns>
        public long MinimumMoney(int[][] transactions)
        {
            // 解是错误的
            throw new NotImplementedException();

            Comparer<int[]> comparer = Comparer<int[]>.Create((a1, a2) =>
            {
                int p1 = a1[1] - a1[0];
                int p2 = a2[1] - a2[0];
                if (p1 != p2) return p1 - p2;
                return a2[0] - a1[0];
            });
            Array.Sort(transactions, comparer);

            long result = 0, len = transactions.Length;
            for (int i = 0; i < len; i++) result += transactions[i][0] - transactions[i][1];
            return result + transactions[^1][1];
        }
    }
}
