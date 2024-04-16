using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3114
{
    public class Solution3114 : Interface3114
    {
        /// <summary>
        /// 分类讨论
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string FindLatestTime(string s)
        {
            char[] chars = new char[5];

            switch ((s[0] == '?', s[1] == '?'))
            {
                case (true, true):
                    chars[0] = '1'; chars[1] = '1';
                    break;
                case (true, false):
                    chars[0] = (s[1] != '0' && s[1] != '1') ? '0' : '1'; chars[1] = s[1];
                    break;
                case (false, true):
                    chars[0] = s[0]; chars[1] = s[0] != '0' ? '1' : '9';
                    break;
                default:
                    chars[0] = s[0]; chars[1] = s[1];
                    break;
            }
            chars[2] = ':';
            chars[3] = s[3] != '?' ? s[3] : '5';
            chars[4] = s[4] != '?' ? s[4] : '9';

            return new string(chars);
        }

        public string FindLatestTime2(string s)
        {
            char[] chars = s.ToArray();

            switch ((s[0] == '?', s[1] == '?'))
            {
                case (true, true):
                    chars[0] = '1'; chars[1] = '1';
                    break;
                case (true, false):
                    chars[0] = (s[1] != '0' && s[1] != '1') ? '0' : '1';
                    break;
                case (false, true):
                    chars[1] = s[0] != '0' ? '1' : '9';
                    break;
                default:
                    break;
            }
            if (s[3] == '?') chars[3] = '5';
            if (s[4] == '?') chars[4] = '9';

            return new string(chars);
        }
    }
}
