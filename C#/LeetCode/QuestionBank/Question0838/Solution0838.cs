using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0838
{
    public class Solution0838 : Interface0838
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="dominoes"></param>
        /// <returns></returns>
        public string PushDominoes(string dominoes)
        {
            char[] chars = dominoes.ToCharArray();
            int len = chars.Length;
            List<int> curr = [], next = [];
            for (int i = 0; i < len; i++) if (dominoes[i] != '.') curr.Add(i);

            int ptr, _ptr;
            while (curr.Count > 0)
            {
                next = [];
                ptr = 0;
                while (ptr < curr.Count)
                {
                    _ptr = curr[ptr];
                    if (chars[_ptr] == 'L')
                    {
                        if (_ptr > 0 && chars[_ptr - 1] == '.')
                        {
                            chars[_ptr - 1] = 'L';
                            next.Add(_ptr - 1);
                        }
                        ptr++;
                    }
                    else  // if (chars[_ptr] == 'R')
                    {
                        if (_ptr < len - 1)
                        {
                            switch (chars[_ptr + 1])
                            {
                                case 'L': ptr += 2; break;
                                case 'R': ptr += 1; break;
                                default:
                                    if (_ptr + 2 < len)
                                    {
                                        if (chars[_ptr + 2] == 'L')
                                        {
                                            ptr += 2;
                                        }
                                        else
                                        {
                                            chars[_ptr + 1] = 'R'; next.Add(_ptr + 1); ptr += 1;
                                        }
                                    }
                                    else
                                    {
                                        chars[_ptr + 1] = 'R'; ptr++;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            ptr++;
                        }
                    }
                }
                curr = next;
            }

            return new string(chars);
        }
    }
}
