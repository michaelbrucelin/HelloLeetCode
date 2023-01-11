using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2283
{
    public class Solution2283_2 : Interface2283
    {
        public bool DigitCount(string num)
        {
            int[] buffer = new int[10];
            for (int i = 0; i < num.Length; i++) buffer[num[i] - '0']++;
            for (int i = 0; i < num.Length; i++) if (num[i] - '0' != buffer[i]) return false;

            return true;
        }

        /// <summary>
        /// 与上面的逻辑一致，但是将char类型的0-9转为int类型的0-9其实是可以通过位运算来实现的
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool DigitCount2(string num)
        {
            int[] buffer = new int[10];
            for (int i = 0; i < num.Length; i++) buffer[num[i] & 15]++;
            for (int i = 0; i < num.Length; i++) if ((num[i] & 15) != buffer[i]) return false;

            return true;
        }
    }
}
