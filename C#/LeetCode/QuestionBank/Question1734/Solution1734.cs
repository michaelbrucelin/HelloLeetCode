using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1734
{
    public class Solution1734 : Interface1734
    {
        /// <summary>
        /// 推理
        /// 见Solution1734.md
        /// </summary>
        /// <param name="encoded"></param>
        /// <returns></returns>
        public int[] Decode(int[] encoded)
        {
            int len = encoded.Length;
            int xor = 0;
            for (int i = len + 1; i > 0; i--) xor ^= i;
            int pre = 0;
            for (int i = 0; i < len; i++) { pre ^= encoded[i]; xor ^= pre; }

            int[] result = new int[len + 1];
            result[0] = xor;
            for (int i = 0; i < len; i++) result[i + 1] = result[i] ^ encoded[i];

            return result;
        }
    }
}
