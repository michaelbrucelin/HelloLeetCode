using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1945
{
    public class Solution1945 : Interface1945
    {
        public int GetLucky(string s, int k)
        {
            StringBuilder sb = new StringBuilder();  // int sint = 0; 用int可能会溢出，即使用long，由于s长度可达100，依然会溢出
            for (int i = 0; i < s.Length; i++) sb.Append((s[i] - 'a' + 1).ToString());
            string str = sb.ToString();
            if (str.Length == 1) return str[0] - '0';

            int result = 0;
            while (k-- > 0)
            {
                result = 0;
                for (int i = 0; i < str.Length; i++) result += str[i] - '0';
                if (result < 10) return result; else str = result.ToString();
            }

            return result;
        }
    }
}
