using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0868
{
    public class Solution0868 : Interface0868
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int BinaryGap(int n)
        {
            while (n > 0 && (n & 1) != 1) n >>= 1;
            if (n == 0) return 0;

            int result = 0, gap = 1;
            while ((n >>= 1) > 0)
            {
                if ((n & 1) != 1)
                {
                    gap++;
                }
                else
                {
                    result = Math.Max(result, gap); gap = 1;
                }
            }

            return result;
        }
    }
}
