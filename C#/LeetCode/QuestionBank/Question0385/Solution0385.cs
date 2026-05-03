using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0385
{
    public class Solution0385
    {
    }

    public class Solution : Interface0385
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public NestedInteger Deserialize(string s)
        {
            return Deserialize(s, 0, s.Length - 1);

            static NestedInteger Deserialize(string s, int left, int right)
            {
                if (s[left] != '[')
                {
                    int num = 0, sign = 1;
                    if (s[left] == '-') { sign = -1; left++; }
                    for (int i = left; i <= right; i++) num = num * 10 + s[i] - '0';
                    return new NestedInteger(sign * num);
                }
                else
                {
                    left++; right--;
                    NestedInteger nested = new NestedInteger();
                    int ptr;
                    while (left <= right)
                    {
                        ptr = left;
                        if (s[ptr] != '[')
                        {
                            while (ptr + 1 <= right && s[ptr + 1] != ',') ptr++;
                            nested.Add(Deserialize(s, left, ptr));
                        }
                        else
                        {
                            int pair = 1;
                            while (++ptr <= right)
                            {
                                if (s[ptr] == '[') pair++; else if (s[ptr] == ']') pair--;
                                if (pair == 0)
                                {
                                    nested.Add(Deserialize(s, left, ptr));
                                    break;
                                }
                            }
                        }
                        left = ptr + 2;
                    }
                    return nested;
                }
            }
        }
    }
}
