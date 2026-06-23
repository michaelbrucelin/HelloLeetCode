using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0926
{
    public class Solution0926 : Interface0926
    {
        /// <summary>
        /// 前缀和
        /// 枚举任意节点作为分隔点需要的翻转次数
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinFlipsMonoIncr(string s)
        {
            int result = s.Length, lsum = 0, rsum = 0, len = s.Length;
            for (int i = 0; i < len; i++) rsum += '1' - s[i];
            if (rsum == 0 || rsum == len) return 0;

            for (int i = 0; i < len; i++)
            {
                if ((result = Math.Min(result, lsum + rsum)) == 0) return 0;
                lsum += s[i] - '0';
                rsum -= '1' - s[i];
            }
            result = Math.Min(result, lsum + rsum);

            return result;
        }
    }
}
