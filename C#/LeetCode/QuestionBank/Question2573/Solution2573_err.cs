using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2573
{
    public class Solution2573_err : Interface2573
    {
        /// <summary>
        /// 贪心 + 构造
        /// 1. 主对角线一定是 n, n-1, ...1
        /// 2. 矩阵一定是主对角线对称的，即 tcp[i][j] == tcp[j][i]
        /// 3. tcp[i][j] <= Min(n-i, n-j)
        /// 基于上面3条规则，一点一点构造即可，如果冲突了，就是不存在
        /// 1. 结果的第一个字符一定是a
        /// 2. 如果lcp[i][j] > 0，那么接下来的几个字符已知，如果lcp[i][j] == 0，那么下一个字符非a即b
        /// 3. 先处理lcp[i][j] > 0（明确的，缩小模糊的范围），再处理lcp[i][j] == 0，选最小的
        /// 
        /// 主体思路没有问题，但是有一些需要打磨的地方，打磨的代码放Solution2573中了
        /// </summary>
        /// <param name="lcp"></param>
        /// <returns></returns>
        public string FindTheString(int[][] lcp)
        {
            int n = lcp.Length;
            for (int i = 0; i < n; i++) if (lcp[i][i] != n - i) return "";
            for (int i = 0; i < n; i++) for (int j = i + 1; j < n; j++) if (lcp[i][j] != lcp[j][i] || lcp[i][j] > n - Math.Max(i, j)) return "";

            char[] buffer = new char[n];
            buffer[0] = 'a';
            for (int i = 0, cnt; i < n; i++) for (int j = i + 1; j < n; j++)
                {
                    if ((cnt = lcp[i][j]) != 0) for (int k = 0; k < cnt; k++)
                        {
                            if (buffer[j + k] == '\0') buffer[j + k] = buffer[i + k]; else if (buffer[j + k] != buffer[i + k]) return "";
                        }
                    if (j + cnt < n) buffer[j + cnt] = buffer[i + cnt] == 'a' ? 'b' : 'a';
                }

            return new string(buffer);
        }
    }
}
