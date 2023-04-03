using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0831
{
    public class Solution0831 : Interface0831
    {
        public string MaskPII(string s)
        {
            int at = s.IndexOf('@');
            if (at != -1)
            {
                return $"{(char)(s[0] | 32)}*****{(char)(s[at - 1] | 32)}{s.Substring(at).ToLower()}";
            }
            else
            {
                s = s.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace("+", "");
                switch (s.Length)
                {
                    case 10:
                        return $"***-***-{s.Substring(6)}";
                    case 11:
                        return $"+*-***-***-{s.Substring(7)}";
                    case 12:
                        return $"+**-***-***-{s.Substring(8)}";
                    case 13:
                        return $"+***-***-***-{s.Substring(9)}";
                    default:
                        throw new Exception("logic error");
                }
            }
        }
    }
}
