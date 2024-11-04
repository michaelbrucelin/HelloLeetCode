using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1108
{
    public class Solution1108 : Interface1108
    {
        public string DefangIPaddr(string address)
        {
            char[] result = new char[address.Length + 6];
            int ptr = 0;
            for (int i = 0; i < address.Length; i++)
            {
                switch (address[i])
                {
                    case '.':
                        result[ptr++] = '['; result[ptr++] = '.'; result[ptr++] = ']';
                        break;
                    default:
                        result[ptr++] = address[i];
                        break;
                }
            }

            return new string(result);
        }

        public string DefangIPaddr2(string address)
        {
            int len = address.Length;
            char[] chars = new char[len + 6];
            for (int i = 0, j = 0; i < len; i++)
            {
                if (address[i] != '.')
                {
                    chars[j++] = address[i];
                }
                else
                {
                    chars[j++] = '[';
                    chars[j++] = '.';
                    chars[j++] = ']';
                }
            }

            return new string(chars);
        }
    }
}
