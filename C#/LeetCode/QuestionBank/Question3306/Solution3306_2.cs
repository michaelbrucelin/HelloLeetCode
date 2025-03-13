using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3306
{
    public class Solution3306_2 : Interface3306
    {
        /// <summary>
        /// 双指针 + 滑动窗口
        /// 令F(k)表示含所有元音且辅音大于等于k的子串数量，则题目要求解的是F(k) - F(k+1)
        /// </summary>
        /// <param name="word"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long CountOfSubstrings(string word, int k)
        {
            return AtLeastX(k) - AtLeastX(k + 1);

            long AtLeastX(int x)
            {
                Dictionary<char, int> vowels = new() { { 'a', 0 }, { 'e', 0 }, { 'i', 0 }, { 'o', 0 }, { 'u', 0 } };
                long result = 0;
                int cnta = 0, cntb = 0, l = 0, r = -1, len = word.Length;
                while (l < len - k - 4 && r < len)
                {
                    if (cnta == 5 && cntb >= x)
                    {
                        result += len - r;
                        if (vowels.ContainsKey(word[l])) { if (--vowels[word[l]] == 0) cnta--; } else { cntb--; }
                        l++;
                    }
                    else
                    {
                        if (++r < len)
                        {
                            if (vowels.ContainsKey(word[r])) { if (++vowels[word[r]] == 1) cnta++; } else { cntb++; }
                        }
                    }
                }

                return result;
            }
        }
    }
}
