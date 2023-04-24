using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1163
{
    public class Solution1163 : Interface1163
    {
        /// <summary>
        /// 贪心
        /// 1. 找出字符串中最大的那个字符，已经所有出现的位置
        /// 2. 多指针向后移，逐位比较即可
        /// 
        /// 逻辑没问题，提交会超时，参考测试用例03
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LastSubstring2(string s)
        {
            int len = s.Length;
            char c = s[0];                          // s中的最大字符
            List<int> pos = new List<int>() { 0 };  // 记录c出现的位置
            for (int i = 1; i < len; i++)
            {
                if (s[i] > c)
                {
                    c = s[i]; pos.Clear(); pos.Add(i);
                }
                else if (s[i] == c)
                {
                    pos.Add(i);
                }
            }

            int offset = 0; char _c; List<int> _pos;
            while (pos.Count > 1)
            {
                offset++;
                _c = s[pos[0] + offset];
                _pos = new List<int>() { pos[0] };
                for (int i = 1, id; i < pos.Count; i++)
                {
                    if ((id = pos[i] + offset) >= len) continue;
                    if (s[id] > _c)
                    {
                        _c = s[id]; _pos.Clear(); _pos.Add(pos[i]);
                    }
                    else if (s[id] == _c)
                    {
                        _pos.Add(pos[i]);
                    }
                }
                pos = _pos;
            }

            return s.Substring(pos[0]);
        }

        /// <summary>
        /// 与LastSubstring()一样，从编码层面精简代码
        /// 
        /// 逻辑没问题，提交会超时，参考测试用例03
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LastSubstring(string s)
        {
            int len = s.Length;
            List<int> pos = new List<int>();               // 哑节点，假定数组中每个位置前面都有一个字符z
            for (int i = 0; i < len; i++) pos.Add(i - 1);

            int offset = 0; char _c; List<int> _pos;
            while (pos.Count > 1)
            {
                offset++;
                _c = s[pos[0] + offset];
                _pos = new List<int>() { pos[0] };
                for (int i = 1, id; i < pos.Count; i++)
                {
                    if ((id = pos[i] + offset) >= len) continue;
                    if (s[id] > _c)
                    {
                        _c = s[id]; _pos.Clear(); _pos.Add(pos[i]);
                    }
                    else if (s[id] == _c)
                    {
                        _pos.Add(pos[i]);
                    }
                }
                pos = _pos;
            }

            return s.Substring(pos[0] + 1);
        }
    }
}
