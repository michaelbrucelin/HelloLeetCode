using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0929
{
    public class Solution0929 : Interface0929
    {
        /// <summary>
        /// 类C逐个字符分析
        /// 简单状态机，state：初始状态0，遇到第一个+，状态1，遇到@，状态2
        /// </summary>
        /// <param name="emails"></param>
        /// <returns></returns>
        public int NumUniqueEmails(string[] emails)
        {
            HashSet<string> result = new HashSet<string>();
            StringBuilder sb = new StringBuilder();
            for (var (i, state, str) = (0, 0, ""); i < emails.Length; i++)
            {
                str = emails[i]; state = 0; sb.Clear();
                for (int j = 0; j < str.Length; j++) switch (state)
                    {
                        case 0:
                            switch (str[j])
                            {
                                case '.': break;
                                case '+': state = 1; break;
                                case '@': sb.Append('@'); state = 2; break;
                                default: sb.Append(str[j]); break;
                            }
                            break;
                        case 1:
                            switch (str[j])
                            {
                                case '@': sb.Append('@'); state = 2; break;
                                default: break;
                            }
                            break;
                        default:
                            sb.Append(str[j]);
                            break;
                    }
                result.Add(sb.ToString());
            }

            return result.Count;
        }
    }
}
