using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2315
{
    public class Solution2315 : Interface2315
    {
        public int CountAsterisks(string s)
        {
            int result = 0;

            bool flag = true;                   // true, 不在| |之间，可以统计
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '*':
                        if (flag) result++;
                        break;
                    case '|':
                        flag = !flag;           // 题目保证有偶数个 | ，所以可以这样编码
                        break;
                    default:
                        break;
                }
            }

            return result;
        }
    }
}
