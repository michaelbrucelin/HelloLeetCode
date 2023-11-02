using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2103
{
    public class Solution2103 : Interface2103
    {
        private Dictionary<char, int> bin = new Dictionary<char, int> { { 'R', 1 }, { 'G', 2 }, { 'B', 4 } };

        public int CountPoints(string rings)
        {
            if (rings.Length < 6) return 0;

            Dictionary<char, int> buffer = new Dictionary<char, int>();
            char key; for (int i = 0; i < rings.Length - 1; i += 2)
            {
                key = rings[i + 1];
                if (buffer.ContainsKey(key))
                    buffer[key] |= bin[rings[i]];
                else
                    buffer.Add(key, bin[rings[i]]);
            }

            int result = 0;
            foreach (int value in buffer.Values) if (value == 7) result++;

            return result;
        }

        public int CountPoints2(string rings)
        {
            if (rings.Length < 6) return 0;

            int[] buffer = new int[10];
            for (int i = 0; i < rings.Length - 1; i += 2)
                buffer[rings[i + 1] & 15] |= bin[rings[i]];

            int result = 0;
            for (int i = 0; i < 10; i++) if (buffer[i] == 7) result++;

            return result;
        }
    }
}
