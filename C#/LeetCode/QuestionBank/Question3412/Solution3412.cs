using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3412
{
    public class Solution3412 : Interface3412
    {
        /// <summary>
        /// 栈
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public long CalculateScore(string s)
        {
            long result = 0;
            Stack<int>[] stacks = new Stack<int>[26];
            for (int i = 0; i < 26; i++) stacks[i] = new Stack<int>();
            for (int i = 0, id, len = s.Length; i < len; i++)
            {
                id = 25 - s[i] + 'a';
                if (stacks[id].Count > 0) result += i - stacks[id].Pop(); else stacks[25 - id].Push(i);
            }

            return result;
        }
    }
}
