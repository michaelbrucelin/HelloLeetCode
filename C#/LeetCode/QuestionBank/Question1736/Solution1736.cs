using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1736
{
    public class Solution1736 : Interface1736
    {
        public string MaximumTime(string time)
        {
            char[] result = time.ToCharArray();
            if (result[0] == '?' && result[1] == '?')
            {
                result[0] = '2'; result[1] = '3';
            }
            else if (result[0] == '?')
            {
                result[0] = result[1] - '0' < 4 ? '2' : '1';
            }
            else if (result[1] == '?')
            {
                result[1] = result[0] - '0' < 2 ? '9' : '3';
            }

            if (result[3] == '?') result[3] = '5';
            if (result[4] == '?') result[4] = '9';

            return new string(result);
        }

        /// <summary>
        /// 与MaximumTime()一样，将if-else换成switch
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public string MaximumTime2(string time)
        {
            char[] result = time.ToCharArray();
            switch ((result[0], result[1]))
            {
                case ('?', '?'):
                    result[0] = '2'; result[1] = '3';
                    break;
                case ('?', < '4'):
                    result[0] = '2';
                    break;
                case ('?', >= '4'):
                    result[0] = '1';
                    break;
                case ( < '2', '?'):
                    result[1] = '9';
                    break;
                case ( >= '2', '?'):
                    result[1] = '3';
                    break;
            }
            if (result[3] == '?') result[3] = '5';
            if (result[4] == '?') result[4] = '9';

            return new string(result);
        }
    }
}
