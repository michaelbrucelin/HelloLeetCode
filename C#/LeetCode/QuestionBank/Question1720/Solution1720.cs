using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1720
{
    public class Solution1720 : Interface1720
    {
        public int[] Decode(int[] encoded, int first)
        {
            int len = encoded.Length;
            int[] result = new int[len + 1];
            result[0] = first;
            for (int i = 1; i <= len; i++) result[i] = result[i - 1] ^ encoded[i - 1];

            return result;
        }
    }
}
