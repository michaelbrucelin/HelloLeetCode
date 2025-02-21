using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1657
{
    public class Solution1657 : Interface1657
    {
        /// <summary>
        /// 数学
        /// 1. 如果两个字符串中每个字母出现的频次完全相同
        ///     那么一定可以通过有限次“交换两个字符位置”（题目的第一种操作）的方式，将一个字符串转为另一个字符串
        ///     本质上就是一次自定义排序
        /// 2. 如果两个字符串出现字母完全相同，频次也完全相同，但是相同字母的频次不同
        ///     那么一定可以通过有限次“替换两个字符”（题目的第二种操作）的方式，将两个字符串调整为第一种的形式
        ///     本质上依然是一次自定义排序
        ///     例如：word1 = "cabbba"  a:2, b:3, c:1
        ///           word2 = "abbccc"  a:1, b:2, c:3
        ///           word1与word2都只含有a b c 3个字符，频次也都是1 2 3，那么通过自定义排序（交换两个字符），就可以调整为第1点的情形
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public bool CloseStrings(string word1, string word2)
        {
            if (word1.Length != word2.Length) return false;

            int mask1 = 0, mask2 = 0, len = word1.Length;
            int[] freq1 = new int[26], freq2 = new int[26];
            for (int i = 0, p1 = 0, p2 = 0; i < len; i++)
            {
                p1 = word1[i] - 'a'; mask1 |= 1 << p1; freq1[p1]++;
                p2 = word2[i] - 'a'; mask2 |= 1 << p2; freq2[p2]++;
            }
            if (mask1 != mask2) return false;

            Array.Sort(freq1); Array.Sort(freq2);
            for (int i = 0; i < 26; i++) if (freq1[i] != freq2[i]) return false;
            return true;
        }
    }
}
