using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0621
{
    public class Solution0621 : Interface0621
    {
        /// <summary>
        /// 贪心
        /// 
        /// 没写完，以后再写
        /// </summary>
        /// <param name="tasks"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int LeastInterval(char[] tasks, int n)
        {
            if (n == 0) return tasks.Length;

            int result = 0, len = tasks.Length;
            int[] freq = new int[26];
            for (int i = 0; i < len; i++) freq[tasks[i] - 'A']++;

            return result;
        }
    }
}
