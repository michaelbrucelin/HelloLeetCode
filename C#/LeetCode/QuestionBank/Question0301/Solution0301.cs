using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0301
{
    public class Solution0301 : Interface0301
    {
        /// <summary>
        /// 二进制枚举
        /// 题目限定最多20个括号，那么二进制枚举的数量为2^20 = 1048576
        /// 
        /// 题目本身不算难，但写起来有些麻烦
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> RemoveInvalidParentheses(string s)
        {
            StringBuilder buffer = new StringBuilder();
            int len = s.Length;
            List<int> pos = [];
            for (int i = 0; i < len; i++) if (s[i] == '(' || s[i] == ')') pos.Add(i);
            int id = pos.Count;
            while (--id >= 0 && s[pos[id]] == '(') pos.RemoveAt(id);                   // 移除最右侧的 (
            id = -1;
            while (++id < pos.Count && s[pos[id]] == ')') pos.RemoveAt(id--);          // 移除最左侧的 )
            if (pos.Count == 0)
            {
                for (int i = 0; i < len; i++) if (s[i] != '(' && s[i] != ')') buffer.Append(s[i]);
                return [buffer.ToString()];
            }

            HashSet<string> result = [];
            int k = pos.Count + 1, p, cnt;
            List<List<int>> poss;
            while (result.Count == 0 && --k > 0)
            {
                poss = EnumKSet(s, pos, k);
                if (poss.Count > 0) foreach (List<int> _pos in poss)
                    {
                        buffer.Length = p = 0; cnt = _pos.Count;
                        for (int i = 0; i < len; i++) if (s[i] == '(' || s[i] == ')')
                            {
                                while (p < cnt && _pos[p] < i) p++;
                                if (p == cnt) continue;
                                if (_pos[p] == i) buffer.Append(s[i]);
                            }
                            else
                            {
                                buffer.Append(s[i]);
                            }
                        result.Add(buffer.ToString());
                    }
            }

            return [.. result];

            static List<List<int>> EnumKSet(string s, List<int> pos, int k)
            {
                List<List<int>> result = [];
                int n = pos.Count;
                int kset = (1 << k) - 1, limit = 1 << n, c, r, mask, offset, lcnt;
                List<int> list;
                while (kset < limit)
                {
                    offset = lcnt = 0;
                    mask = kset;
                    list = [];
                    while (mask > 0)
                    {
                        if ((mask & 1) == 1) switch (s[pos[offset]])
                            {
                                case '(': lcnt++; list.Add(pos[offset]); break;
                                case ')': if (lcnt > 0) { lcnt--; list.Add(pos[offset]); } else goto CONTINUE; break;
                                default: break;
                            }
                        mask >>= 1; offset++;
                    }
                    if (lcnt == 0) result.Add(list);
                    CONTINUE:;
                    c = kset & -kset;
                    r = kset + c;
                    kset = (((r ^ kset) >> 2) / c) | r;
                }

                return result;
            }
        }
    }
}
