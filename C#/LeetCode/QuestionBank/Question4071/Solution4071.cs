using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question4071
{
    public class Solution4071 : Interface4071
    {
        /// <summary>
        /// 预处理 + 枚举翻转位置
        /// 逻辑同Solution4070，翻转一个尾缀是唬人的，翻转只影响“接缝”位置，内部没有影响
        /// </summary>
        /// <param name="n"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinRotations(int n, string s)
        {
            int[,] cnts = new int[10, 10];
            for (int i = 0; i < 10; i++) for (int j = i + 1; j < 10; j++) cnts[i, j] = cnts[j, i] = Math.Min(j - i, i + 10 - j);

            int result = cnts[0, s[0] & 15], len = s.Length;
            for (int i = 1; i < len; i++) result += cnts[s[i - 1] & 15, s[i] & 15];

            int last = s[^1] & 15, max = cnts[0, s[0] & 15] - cnts[0, last];
            max = Math.Max(max, 0);
            for (int i = 0, j = 1; j < len && max < 5; i++, j++) max = Math.Max(max, cnts[s[i] & 15, s[j] & 15] - cnts[s[i] & 15, last]);

            return result - max;
        }
    }
}
