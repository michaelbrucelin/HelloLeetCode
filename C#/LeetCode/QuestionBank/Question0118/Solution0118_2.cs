using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0118
{
    public class Solution0118_2 : Interface0118
    {
        /// <summary>
        /// 数学
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public IList<IList<int>> Generate(int numRows)
        {
            List<IList<int>> result = new List<IList<int>>() { new int[] { 1 } };
            if (numRows == 1) return result;

            for (int i = 2; i <= numRows; i++)
            {
                IList<int> row = new int[i];
                int half = (i - 1) >> 1;
                for (int j = 0; j <= half; j++) row[j] = nCr(i - 1, j);
                for (int j = 0; j <= half; j++) row[i - 1 - j] = row[j];
                result.Add(row);
            }

            return result;
        }

        private static int nCr(int n, int r)
        {
            long result = 1;
            for (int i = 0; i < r; i++) result *= n - i;
            for (int i = 1; i <= r; i++) result /= i;

            return (int)result;
        }
    }
}
