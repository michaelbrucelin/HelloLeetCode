using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3606
{
    public class Solution3606 : Interface3606
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="code"></param>
        /// <param name="businessLine"></param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        public IList<string> ValidateCoupons(string[] code, string[] businessLine, bool[] isActive)
        {
            int len = code.Length;
            List<string>[] _result = [[], [], [], []];
            Regex regex = new Regex(@"^[a-zA-Z0-9_]+$");
            for (int i = 0; i < len; i++) if (isActive[i]) switch (businessLine[i])
                    {
                        case "electronics": if (regex.IsMatch(code[i])) _result[0].Add(code[i]); break;
                        case "grocery": if (regex.IsMatch(code[i])) _result[1].Add(code[i]); break;
                        case "pharmacy": if (regex.IsMatch(code[i])) _result[2].Add(code[i]); break;
                        case "restaurant": if (regex.IsMatch(code[i])) _result[3].Add(code[i]); break;
                        default: break;
                    }
            for (int i = 0; i < 4; i++) _result[i].Sort(StringComparer.Ordinal);

            List<string> result = new List<string>();
            for (int i = 0; i < 4; i++) result.AddRange(_result[i]);
            return result;
        }
    }
}
