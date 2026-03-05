using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1784
{
    public class Solution1784_2 : Interface1784
    {
        /// <summary>
        /// 脑筋急转弯
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool CheckOnesSegment(string s)
        {
            return !s.Contains("01");
        }
    }
}
