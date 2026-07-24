using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0306
{
    public class Solution0306 : Interface0306
    {
        /// <summary>
        /// 枚举
        /// 枚举出前两个值，就确认了后面的所有值
        /// .net中有Int128这个数据类型，可以承载题目的数据范围，其实long就够用
        /// 
        /// 没提交，稍后改为long版，字符串版再提交
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsAdditiveNumber(string num)
        {
            int len = num.Length, _len;
            Int128 n1 = 0, n2, _n1, _n2, _n3; string _n3str;
            for (int i = 0; i < len; i++)
            {
                if (i > 0 && num[0] == '0') break;              // 没有含前导0的数字
                n1 = n1 * 10 + num[i] - '0'; n2 = 0;
                for (int j = i + 1, p; j < len; j++)
                {
                    if (j > i + 1 && num[i + 1] == '0') break;  // 没有含前导0的数字
                    n2 = n2 * 10 + num[j] - '0';
                    _n3 = n1 + n2;
                    if ((_len = (_n3str = _n3.ToString()).Length) > len - j - 1) break;
                    p = j; _n1 = n1; _n2 = n2;
                    while (true)
                    {
                        if (_len > len - p - 1) break;
                        for (int k = 0; k < _len; k++) if (_n3str[k] != num[p + 1 + k]) goto CONTINUE;
                        if (p + _len + 1 == len) return true;
                        _n1 = _n2; _n2 = _n3; _n3 = _n1 + _n2; p += _len; _len = (_n3str = _n3.ToString()).Length;
                    }
                CONTINUE:;
                }
            }

            return false;
        }
    }
}
