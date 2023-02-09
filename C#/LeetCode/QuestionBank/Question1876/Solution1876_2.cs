using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1876
{
    public class Solution1876_2 : Interface1876
    {
        public int CountGoodSubstrings(string s)
        {
            if (s.Length < 3) return 0;

            int result = 0;
            char c1, c2 = s[0], c3 = s[1];
            for (int i = 2; i < s.Length; i++)
            {
                c1 = c2; c2 = c3; c3 = s[i];
                if (c1 != c2 && c1 != c3 && c2 != c3) result++;
            }

            return result;
        }

        /// <summary>
        /// 用队列实现一次，没有实际意义，写着玩的
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int CountGoodSubstrings2(string s)
        {
            if (s.Length < 3) return 0;

            int result = 0;
            Queue<char> queue = new Queue<char>();
            queue.Enqueue(' '); queue.Enqueue(s[0]); queue.Enqueue(s[1]);
            char[] buffer = new char[3];
            for (int i = 2; i < s.Length; i++)
            {
                queue.Dequeue(); queue.Enqueue(s[i]);
                for (int j = 0; j < 3; j++)
                {
                    buffer[j] = queue.Dequeue(); queue.Enqueue(buffer[j]);
                }
                if (buffer[0] != buffer[1] && buffer[0] != buffer[2] && buffer[1] != buffer[2]) result++;
            }

            return result;
        }
    }
}
