using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2433
{
    public class Solution2433 : Interface2433
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="pref"></param>
        /// <returns></returns>
        public int[] FindArray(int[] pref)
        {
            int len = pref.Length;
            int[] result = new int[len];
            result[0] = pref[0];
            for (int i = 1; i < len; i++) result[i] = pref[i] ^ pref[i - 1];

            return result;
        }
    }
}
