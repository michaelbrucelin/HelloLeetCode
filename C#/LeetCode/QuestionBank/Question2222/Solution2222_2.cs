using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2222
{
    public class Solution2222_2 : Interface2222
    {
        /// <summary>
        /// 贡献法
        /// 只有两种可能，010 与 101，所以枚举中间的元素，看看这个贡献了多少个结果即可
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public long NumberOfWays(string s)
        {
            int len = s.Length;
            int[,] cnts = new int[2, 2];  // cnts[0,0] 左侧 0, cnts[0,1] 右侧 0, cnts[1,0] 左侧 1, cnts[1,1] 右侧 1
            for (int i = 1; i < len; i++) { cnts[0, 1] += '1' - s[i]; cnts[1, 1] += s[i] - '0'; }

            long result = 0; len--;
            for (int i = 1, j; i < len; i++)
            {
                cnts[0, 0] += '1' - s[i - 1]; cnts[0, 1] -= '1' - s[i];
                cnts[1, 0] += s[i - 1] - '0'; cnts[1, 1] -= s[i] - '0';
                j = '1' - s[i];
                result += 1L * cnts[j, 0] * cnts[j, 1];
            }

            return result;
        }
    }
}
