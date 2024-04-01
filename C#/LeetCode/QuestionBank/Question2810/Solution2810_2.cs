using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2810
{
    public class Solution2810_2 : Interface2810
    {
        /// <summary>
        /// 双端队列
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string FinalString(string s)
        {
            bool tail = true;
            LinkedList<char> list = new LinkedList<char>();
            foreach (char c in s)
            {
                if (c == 'i')
                {
                    tail = !tail;
                }
                else
                {
                    if (tail) list.AddLast(c); else list.AddFirst(c);
                }
            }

            if (tail)
                return new string(list.ToArray());
            else
                return new string(list.Reverse().ToArray());
        }
    }
}
