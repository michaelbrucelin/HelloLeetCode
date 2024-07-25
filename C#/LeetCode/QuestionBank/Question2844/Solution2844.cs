using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2844
{
    public class Solution2844 : Interface2844
    {
        /// <summary>
        /// 数学
        /// 找循环节，25的循环节是4，能被25整除的数字的结尾只有00, 25, 50, 75这4种可能
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int MinimumOperations(string num)
        {
            if (num == "0") return 0;

            int result = num.Length, p, len = num.Length;
            // 00 50 0
            p = len - 1;
            while (p >= 0 && num[p] != '0') p--;
            if (--p >= 0)
            {
                while (p >= 0 && num[p] != '0' && num[p] != '5') p--;
                if (p >= 0) result = len - p - 2; else result = len - 1;
            }
            // 25 75
            p = len - 1;
            while (p >= 0 && num[p] != '5') p--;
            if (--p >= 0)
            {
                while (p >= 0 && num[p] != '2' && num[p] != '7') p--;
                if (p >= 0) result = Math.Min(result, len - p - 2);
            }

            return result;
        }
    }
}
