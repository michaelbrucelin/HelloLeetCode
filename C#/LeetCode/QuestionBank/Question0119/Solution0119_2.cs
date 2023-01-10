using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0119
{
    public class Solution0119_2 : Interface0119
    {
        /// <summary>
        /// 模拟2
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public IList<int> GetRow(int rowIndex)
        {
            List<int> result = new List<int>() { 1 };

            int t1, t2;
            for (int i = 1; i <= rowIndex; i++)
            {
                t2 = 1;
                for (int j = 1; j < result.Count; j++)
                {
                    t1 = t2; t2 = result[j]; result[j] += t1;
                }
                result.Add(1);
            }

            return result;
        }
    }
}
