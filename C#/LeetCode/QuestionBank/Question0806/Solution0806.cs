using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0806
{
    public class Solution0806 : Interface0806
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="widths"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public int[] NumberOfLines(int[] widths, string s)
        {
            int limit = 100, line = 0, width = limit;
            for (int i = 0, _width; i < s.Length; i++)
            {
                _width = widths[s[i] - 'a'];
                if ((width += _width) > limit)
                {
                    line++; width = _width;
                }
            }

            return new int[] { line, width };
        }
    }
}
