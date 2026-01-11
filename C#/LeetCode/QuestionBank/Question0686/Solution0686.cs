using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0686
{
    public class Solution0686 : Interface0686
    {
        /// <summary>
        /// 贪心 + KMP
        /// 拼接字符串a是其长度 >= b 后，尝试一次，再拼接一个a，再尝试一次即可
        /// 不需要再拼接了，反证法即可
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int RepeatedStringMatch(string a, string b)
        {
            int result = (int)(Math.Ceiling(1D * b.Length / a.Length));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result; i++) sb.Append(a);
            if (sb.ToString().Contains(b)) return result;
            sb.Append(a);
            if (sb.ToString().Contains(b)) return result + 1;

            return -1;
        }
    }
}
