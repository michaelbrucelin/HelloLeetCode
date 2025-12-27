using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3783
{
    public class Solution3783 : Interface3783
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MirrorDistance(int n)
        {
            int m = 0, _n = n;
            while (_n > 0)
            {
                m = m * 10 + _n % 10;
                _n /= 10;
            }

            return Math.Abs(m - n);
        }
    }
}
