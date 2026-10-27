using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3963
{
    public class Solution3963 : Interface3963
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public string[] CreateGrid(int m, int n)
        {
            string[] result = new string[m];
            result[0] = new string('.', n);
            char[] line = new char[n];
            for (int i = 0; i < n - 1; i++) line[i] = '#';
            line[n - 1] = '.';
            for (int i = 1; i < m; i++) result[i] = new string(line);

            return result;
        }
    }
}
