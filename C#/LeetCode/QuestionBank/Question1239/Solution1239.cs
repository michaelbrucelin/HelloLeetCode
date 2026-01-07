using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1239
{
    public class Solution1239 : Interface1239
    {
        /// <summary>
        /// 枚举
        /// 使用二进制枚举每一种可能，使用一个整型掩码表示一个字符串，加速每一次比较
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MaxLength(IList<string> arr)
        {
            List<int> masks = [], lens = [];
            int mask, offset, upper = (1 << 26) - 1;
            foreach (string s in arr)
            {
                mask = 0;
                foreach (char c in s)
                {
                    offset = c - 'a';
                    if (((mask >> offset) & 1) != 0) goto CONTINUE; else mask |= (1 << offset);
                }
                if (mask == upper) return 26;
                masks.Add(mask); lens.Add(s.Length);
            CONTINUE:;
            }
            if (masks.Count == 0) return 0;
            if (masks.Count == 1) return lens[0];

            int result = 0, _result, _mask; upper = 1 << masks.Count;
            for (int i = 1; i < upper; i++)
            {
                _mask = i; _result = 0; mask = 0; offset = 0;
                while (_mask > 0)
                {
                    if ((_mask & 1) == 1)
                    {
                        if ((mask & masks[offset]) != 0) goto CONTINUE; else { mask |= masks[offset]; _result += lens[offset]; }
                    }
                    _mask >>= 1; offset++;
                }
                if (_result == 26) return 26;
                result = Math.Max(result, _result);
            CONTINUE:;
            }

            return result;
        }
    }
}
