using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0119
{
    public class Solution0119_5 : Interface0119
    {
        public IList<int> GetRow(int rowIndex)
        {
            int[] result = new int[rowIndex + 1]; result[0] = 1; result[rowIndex] = 1;
            int half = rowIndex >> 1;
            for (int i = 1; i <= half; i++) result[i] = (int)((long)result[i - 1] * (rowIndex - i + 1) / i);
            for (int i = 1; i <= half; i++) result[rowIndex - i] = result[i];

            return result;
        }
    }
}
