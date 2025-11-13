using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3228
{
    public class Solution3228 : Interface3228
    {
        /// <summary>
        /// 倒序遍历
        /// 例如
        /// 1    001    1    01
        ///                  这个1贡献为0
        ///             这个1后面有1个01，贡献为1
        ///        这个1后面有1个01，贡献为1
        /// 这个1后面有2个01，贡献为2
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MaxOperations(string s)
        {
            int result = 0, cnt = 1 - (s[^1] & 15);
            for (int i = s.Length - 2; i >= 0; i--)
            {
                if (s[i] == '0')
                {
                    if (s[i + 1] == '1') cnt++;
                }
                else
                {
                    result += cnt;
                }
            }

            return result;
        }
    }
}
