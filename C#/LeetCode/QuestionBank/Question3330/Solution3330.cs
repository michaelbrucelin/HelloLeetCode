using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3330
{
    public class Solution3330 : Interface3330
    {
        /// <summary>
        /// 分析
        /// 如果一个字符连续x次，如果发生错误，有x-1种错法，即只要当前字符与前面字符相同，就多了一种“错法”
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int PossibleStringCount(string word)
        {
            int result = 1, len = word.Length;  // 没有敲错，1种可能
            for (int i = 1; i < len; i++) if (word[i] == word[i - 1]) result++;

            return result;
        }
    }
}
