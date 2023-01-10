using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0119
{
    public class Solution0119_4 : Interface0119
    {
        public IList<int> GetRow(int rowIndex)
        {
            int[] result = new int[rowIndex + 1];
            for (int i = 0; i <= rowIndex; i++)
            {
                result[i] = 1;
                for (int j = i - 1; j > 0; j--) result[j] += result[j - 1];
            }

            return result;
        }
    }
}
