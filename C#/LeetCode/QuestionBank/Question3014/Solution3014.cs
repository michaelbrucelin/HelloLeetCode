using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3014
{
    public class Solution3014 : Interface3014
    {
        public int MinimumPushes(string word)
        {
            int len = word.Length;
            switch (len)
            {
                case <= 8: return len;
                case <= 16: return 8 + ((len - 8) << 1);
                case <= 24: return 24 + (len - 16) * 3;
                default: return 48 + ((len - 24) << 2);
            }
        }

        public int MinimumPushes2(string word)
        {
            int len = word.Length;
            return (len) switch
            {
                <= 8 => len,
                <= 16 => 8 + ((len - 8) << 1),
                <= 24 => 24 + (len - 16) * 3,
                _ => 48 + ((len - 24) << 2)
            };
        }
    }
}
