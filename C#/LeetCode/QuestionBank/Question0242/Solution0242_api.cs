using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0242
{
    public class Solution0242_api : Interface0242
    {
        /// <summary>
        /// 进阶的话，算法无需更改
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            return Enumerable.SequenceEqual(s.OrderBy(c => c), t.OrderBy(c => c));
        }
    }
}
