using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question4000
{
    public class Solution4000 : Interface4000
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="n"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LargestInteger(int n, int s)
        {
            if (s > n * 9) return -1;
            if (s == 0) return 0;

            int result = 0;
            for (int i = 0; i < n; i++) switch (s)
                {
                    case > 8:
                        result = result * 10 + 9; s -= 9;
                        break;
                    case > 0:
                        result = result * 10 + s; s = 0;
                        break;
                    default:
                        result *= 10;
                        break;
                }
            return result;
        }
    }
}
