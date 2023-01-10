using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0119
{
    public class Solution0119 : Interface0119
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public IList<int> GetRow(int rowIndex)
        {
            List<int> result = new List<int>() { 1 };

            for (int i = 1; i <= rowIndex; i++)
            {
                List<int> row = new List<int>() { 1 };
                for (int j = 0; j < result.Count - 1; j++) row.Add(result[j] + result[j + 1]);
                row.Add(1);
                result = row;
            }

            return result;
        }
    }
}
