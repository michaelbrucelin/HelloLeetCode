using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2094
{
    public class Solution2094 : Interface2094
    {
        /// <summary>
        /// 逆向思维
        /// 遍历100-999之间的偶数，看一下这个偶数能不能由digits中的数字构成
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public int[] FindEvenNumbers(int[] digits)
        {
            int[] freq = new int[10];
            for (int i = 0; i < digits.Length; i++) freq[digits[i]]++;

            List<int> result = new List<int>();
            int _num; int[] _freq = new int[10];
            for (int i = 100; i < 1000; i += 2)
            {
                Array.Fill(_freq, 0);
                _num = i;
                while (_num > 0) { _freq[_num % 10]++; _num /= 10; }
                for (int j = 0; j < 10; j++) if (_freq[j] > freq[j]) goto CONTINUE;
                result.Add(i);
                CONTINUE:;
            }

            return result.ToArray();
        }
    }
}
