using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1189
{
    public class Solution1189 : Interface1189
    {
        private static readonly int[] map = new int[] { 0, 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 3, 5, 2, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };

        public int MaxNumberOfBalloons(string text)
        {
            int[] freq = new int[6];
            for (int i = 0; i < text.Length; i++) freq[map[text[i] - 'a']]++;

            int result = freq[0];
            if (result > 0)
            {
                freq[3] >>= 1; freq[4] >>= 1;
                for (int i = 1; i < 5; i++) result = Math.Min(result, freq[i]);
            }

            return result;
        }
    }
}
