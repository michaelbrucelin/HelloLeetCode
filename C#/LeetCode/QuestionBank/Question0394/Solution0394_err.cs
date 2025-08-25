using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0394
{
    public class Solution0394_err : Interface0394
    {
        /// <summary>
        /// 模拟
        /// 
        /// 没好好审题，也没好好看看示例，当成形式一定是 \d[xxx]\d\d[xxx] 的形式了
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string DecodeString(string s)
        {
            List<char> list = new List<char>();
            int k, pl = 0, pr = 0, len = s.Length;
            while (pr < len)
            {
                k = 0;
                while (char.IsDigit(s[pl])) k = k * 10 + (s[pl++] & 15);
                pr = ++pl;
                while (s[pr] != ']') pr++;
                for (int i = 0; i < k; i++) for (int j = pl; j < pr; j++) list.Add(s[j]);
                pl = ++pr;
            }

            return new string(list.ToArray());
        }
    }
}
