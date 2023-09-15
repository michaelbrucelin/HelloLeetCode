using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0748
{
    public class Solution0050 : Interface0050
    {
        public string ShortestCompletingWord(string licensePlate, string[] words)
        {
            int cnt = 0; int[] plate = new int[26];
            foreach (char c in licensePlate)
            {
                if (char.IsLetter(c))  // LeetCode上面没有char.IsAsciiLetter()方法
                {
                    cnt++; if (char.IsLower(c)) plate[c - 'a']++; else plate[c - 'A']++;
                }
            }

            string result = new string(' ', 16);  // 题目保证word.Length <= 15
            int[] check = new int[26];
            foreach (string word in words)
            {
                if (word.Length < cnt) continue;
                Array.Fill(check, 0);
                foreach (char c in word) check[c - 'a']++;
                for (int i = 0; i < 26; i++) if (check[i] < plate[i]) goto Continue;
                if (word.Length < result.Length) result = word;
                Continue:;
            }

            return result;
        }
    }
}
