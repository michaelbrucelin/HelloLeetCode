using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3324
{
    public class Solution3324 : Interface3324
    {
        /// <summary>
        /// 模拟
        /// 这个场景感觉StringBuilder没什么用
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<string> StringSequence(string target)
        {
            List<string> result = [""];
            int ptr = 0, cnt;
            foreach (char c in target)
            {
                cnt = c - 'a';
                for (int i = 0; i <= cnt; i++) result.Add($"{result[ptr]}{(char)('a' + i)}");
                ptr += cnt + 1;
            }

            return result[1..];
        }
    }
}
