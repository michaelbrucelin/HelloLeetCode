using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0122
{
    public class Solution0122 : Interface0122
    {
        public string PathEncryption(string path)
        {
            char[] chars = path.ToCharArray();
            for (int i = 0; i < chars.Length; i++) if (chars[i] == '.') chars[i] = ' ';

            return new string(chars);
        }
    }
}
