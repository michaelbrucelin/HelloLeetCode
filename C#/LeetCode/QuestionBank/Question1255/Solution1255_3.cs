using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1255
{
    public class Solution1255_3 : Interface1255
    {
        /// <summary>
        /// DP
        /// 1. 将letters整理为词频（每个字符的数量），相当于总的资源
        /// 2. 将words中的每个word整理为词频与得分，相当于消耗相应的资源可以得到多少报酬
        /// 这样就变成“金矿”问题了，可以使用递归、记忆化搜索与DP至少3种方式求解
        /// 
        /// 这里用DP求解一下，具体解释见Solution1255_3.md
        /// </summary>
        /// <param name="words"></param>
        /// <param name="letters"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public int MaxScoreWords(string[] words, char[] letters, int[] score)
        {
            (int[] mask, int point)[] items = new (int[] mask, int point)[words.Length];
            for (int i = 0; i < words.Length; i++) items[i] = Encoding(words[i], score);
            int[] rsrc = new int[26];  // rsrc: resource
            for (int i = 0; i < letters.Length; i++) rsrc[letters[i] - 'a']++;

            (int[] mask, int point)[] dp = new (int[] mask, int point)[26];
            for (int i = 0; i < 26; i++) dp[i] = (new int[26], 0);
            for (int i = 0; i < items.Length; i++)
            {
                int[] _rsrc = new int[26];
                (int[] mask, int point)[] _dp = new (int[] mask, int point)[26];
                for (int j = 0; j < 26; j++)
                {
                    _rsrc[j] = rsrc[j];
                    if (!GreaterEqual(_rsrc, items[i].mask))
                    {
                        _dp[j] = dp[j];
                    }
                    else
                    {
                        int point = 0; _rsrc = Sub(_rsrc, items[i].mask);
                        for (int k = 25; k >= 0; k--)
                        {
                            if (GreaterEqual(_rsrc, dp[k].mask))
                            {
                                point = dp[k].point; break;
                            }
                        }
                        // 比较“用”与“不用”哪个得分高，但是突然想到如果得分一样，没有办法确认哪个成本更低
                        // 例如"a1b1c1"与"d1e1f1"不能说哪个成本低，哪个成本高，所以没有继续往下写
                    }
                }
                dp = _dp;
            }

            return dp[25].point;
        }

        private (int[] mask, int point) Encoding(string word, int[] score)
        {
            int[] mask = new int[26]; int point = 0;
            for (int i = 0; i < word.Length; i++)
            {
                int id = word[i] - 'a'; mask[id]++; point += score[id];
            }
            return (mask, point);
        }

        private int[] Add(int[] mask1, int[] mask2)
        {
            int[] mask = new int[26];
            for (int i = 0; i < 26; i++) mask[i] = mask1[i] + mask2[i];
            return mask;
        }

        private int[] Sub(int[] mask1, int[] mask2)
        {
            int[] mask = new int[26];
            for (int i = 0; i < 26; i++) mask[i] = mask1[i] - mask2[i];
            return mask;
        }

        private bool GreaterEqual(int[] mask1, int[] mask2)
        {
            for (int i = 0; i < 26; i++) if (mask1[i] < mask2[i]) return false;
            return true;
        }
    }
}
