using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0118
{
    public class Solution0118 : Interface0118
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public IList<IList<int>> Generate(int numRows)
        {
            List<IList<int>> result = new List<IList<int>>() { new List<int>() { 1 } };
            if (numRows == 1) return result;

            for (int i = 2; i <= numRows; i++)
            {
                IList<int> row = new List<int>() { 1 };
                IList<int> _row = result[i - 2];
                for (int j = 0; j < _row.Count - 1; j++) row.Add(_row[j] + _row[j + 1]);
                row.Add(1);
                result.Add(row);
            }

            return result;
        }
    }
}
