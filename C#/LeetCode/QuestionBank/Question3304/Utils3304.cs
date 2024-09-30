using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3304
{
    public class Utils3304
    {
        public void Dial()
        {
            char[] dial = new char[501];
            for (int i = 1; i < 501; i++) dial[i] = KthCharacter(i);
            Utils.Dump(dial);
        }

        public void DialInt()
        {
            int[] dial = new int[501];
            for (int i = 1; i < 501; i++) dial[i] = KthCharacter(i);
            Utils.Dump(dial.Select(x => x - 97));
        }

        private char KthCharacter(int k)
        {
            int[] chars = new int[k];
            int n = 1, _n;
            while (n < k)
            {
                _n = n;
                for (int i = 0; i < _n && n < k; i++) chars[n++] = chars[i] + 1;
            }

            return (char)(chars[k - 1] % 26 + 'a');
        }
    }
}
