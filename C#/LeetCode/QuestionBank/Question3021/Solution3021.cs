using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3021
{
    public class Solution3021 : Interface3021
    {
        /// <summary>
        /// 脑筋急转弯
        /// 只要一奇一偶即可
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public long FlowerGame(int n, int m)
        {
            return 1L * ((n + 1) / 2) * (m / 2) + 1L * (n / 2) * ((m + 1) / 2);
        }
    }
}
