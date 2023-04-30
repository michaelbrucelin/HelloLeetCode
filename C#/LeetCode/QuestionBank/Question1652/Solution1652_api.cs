using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1652
{
    public class Solution1652_api : Interface1652
    {
        public int[] Decrypt(int[] code, int k)
        {
            int len = code.Length;

            if (k < 0)
                return Enumerable.Range(0, len).Select(i => Enumerable.Range(1, -k).Select(j => code[(i - j + len) % len]).Sum()).ToArray();
            else if (k > 0)
                return Enumerable.Range(0, len).Select(i => Enumerable.Range(1, k).Select(j => code[(i + j) % len]).Sum()).ToArray();
            else
                return Enumerable.Repeat(0, len).ToArray();
        }

        public int[] Decrypt2(int[] code, int k)
        {
            int len = code.Length;

            if (k != 0)
                return Enumerable.Range(0, len).Select(i => Enumerable.Range(1, Math.Abs(k)).Select(j => code[(i + Math.Sign(k) * j + len) % len]).Sum()).ToArray();
            else
                return Enumerable.Repeat(0, len).ToArray();
        }
    }
}
