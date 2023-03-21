using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1935
{
    public class Solution1935 : Interface1935
    {
        /// <summary>
        /// 双指针
        /// 使用类似于C的朴素方式去解
        /// </summary>
        /// <param name="text"></param>
        /// <param name="brokenLetters"></param>
        /// <returns></returns>
        public int CanBeTypedWords(string text, string brokenLetters)
        {
            bool[] set = new bool[27];  // set[0]不使用
            for (int i = 0; i < brokenLetters.Length; i++) set[brokenLetters[i] & 31] = true;

            int result = 0, ptr_l = 0, ptr_r, len = text.Length;
            while (ptr_l < len)
            {
            }

            return result;
        }
    }
}
