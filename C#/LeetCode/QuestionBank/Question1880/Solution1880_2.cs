using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1880
{
    public class Solution1880_2 : Interface1880
    {
        /// <summary>
        /// 模拟加法
        /// 模拟加法逐位相加，写着玩的
        /// </summary>
        /// <param name="firstWord"></param>
        /// <param name="secondWord"></param>
        /// <param name="targetWord"></param>
        /// <returns></returns>
        public bool IsSumEqual(string firstWord, string secondWord, string targetWord)
        {
            int firstLen = firstWord.Length, secondLen = secondWord.Length, targetLen = targetWord.Length;
            int carry = 0, id = 0, first, second, target;
            while (id < firstLen || id < secondLen || id < targetLen)
            {
                first = id < firstLen ? firstWord[firstLen - id - 1] - 'a' : 0;
                second = id < secondLen ? secondWord[secondLen - id - 1] - 'a' : 0;
                target = id < targetLen ? targetWord[targetLen - id - 1] - 'a' : 0;
                if (target != (first + second + carry) % 10) return false;
                carry = (first + second + carry) / 10;
                id++;
            }
            if (carry != 0) return false;

            return true;
        }
    }
}
