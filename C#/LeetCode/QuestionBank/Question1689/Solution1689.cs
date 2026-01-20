using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1689
{
    public class Solution1689 : Interface1689
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MinPartitions(string n)
        {
            int result = 1, len = n.Length;
            for (int i = 0; i < len; i++)
            {
                if (n[i] == '9') return 9;
                result = Math.Max(result, n[i] - '0');
            }

            return result;
        }
    }
}
