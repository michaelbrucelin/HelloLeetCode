using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2573
{
    public class Solution2573 : Interface2573
    {
        /// <summary>
        /// 贪心 + 构造
        /// 核心思路同Solution2573_err，这里做了些打磨与改进
        /// 1. 将buffer由new char[n]，改为new char[char[]]，其中内部的char[]永远只存放一个字符
        ///     之所以要这样做，是因为如果两个位置字符相同，就放同一个数组，这样稍后需要调整，O(1)的改动全部需要改动的地方
        ///     而C#中没有指针，那就用数组代替指针
        /// 2. 如果lcp[i][j] == 0, 继续找lcp[i+1][j]
        /// 
        /// 先不写了，上面的用数组代替指针，现在由别的想法了，如果用并查集，将相等的位置分为一组呢？
        /// </summary>
        /// <param name="lcp"></param>
        /// <returns></returns>
        public string FindTheString(int[][] lcp)
        {
            int n = lcp.Length;
            for (int i = 0; i < n; i++) if (lcp[i][i] != n - i) return "";
            for (int i = 0; i < n; i++) for (int j = i + 1; j < n; j++) if (lcp[i][j] != lcp[j][i] || lcp[i][j] > n - Math.Max(i, j)) return "";

            char[][] buffer = new char[n][];
            for (int i = 0; i < n; i++) buffer[i] = new char[1];
            buffer[0] = ['a'];
            for (int i = 0, cnt; i < n; i++) for (int j = i + 1; j < n; j++)
                {
                    if ((cnt = lcp[i][j]) != 0) for (int k = 0; k < cnt; k++)
                        {
                            if (buffer[j + k] == null) buffer[j + k] = buffer[i + k]; else if (buffer[j + k][0] != buffer[i + k][0]) return "";
                        }
                    if (j + cnt < n)
                    {
                        // 终止符
                    }
                }

            char[] _buffer = new char[n];
            for (int i = 0; i < n; i++) _buffer[i] = buffer[i][0];
            return new string(_buffer);
        }
    }
}
