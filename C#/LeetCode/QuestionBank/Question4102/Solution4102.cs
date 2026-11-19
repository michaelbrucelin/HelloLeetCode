using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question4102
{
    public class Solution4102 : Interface4102
    {
        /// <summary>
        /// 计数
        /// 例如 abbabcababcaabbb
        /// 长度为 1 与长度为 2 的有 16 + 15 = 31 个
        /// 找出字符串中的 abc，拆分字符串，拆分成 abbab，bcabab，bcaabbb 3个字符串
        /// 统计每个字符串长度从 3 开始的子字符串的个数即可
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public long CountValidSubstrings(string s)
        {
            if (s.Length < 3) return (s.Length << 1) - 1;

            long result = 0; int len = s.Length;
            result += len + len - 1;
            List<int> list = [0];     // 记录每个abc子串b的下标
            for (int i = 1, j = 2; j < len; i++, j++) if ((s[i - 1], s[i], s[j]) == ('a', 'b', 'c')) list.Add(i);
            list.Add(len - 1);
            for (int i = 1, cnt = list.Count, _len; i < cnt; i++)
            {
                _len = list[i] - list[i - 1];
                result += (1L * _len * (_len - 1)) >> 1;
            }

            return result;
        }
    }
}
