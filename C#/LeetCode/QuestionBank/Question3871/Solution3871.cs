using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3871
{
    public class Solution3871 : Interface3871
    {
        /// <summary>
        /// 分段函数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public long CountCommas(long n)
        {
            long result = 0, range = 1000, cnt = 1, _cnt = 0;
            while (true)
            {
                if (n < range) break;
                result += cnt * (Math.Min(range * 10 - 1, n) - range + 1);
                range *= 10;
                if (++_cnt == 3)
                {
                    cnt++; _cnt = 0;
                }
            }

            return result;
        }
    }
}
