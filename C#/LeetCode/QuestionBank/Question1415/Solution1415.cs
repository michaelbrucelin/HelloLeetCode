using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1415
{
    public class Solution1415 : Interface1415
    {
        /// <summary>
        /// 回溯
        /// 这道题有数学递推解法（Solution1415_2），由于数据量比较小，这里暴力回溯写一下
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string GetHappyString(int n, int k)
        {
            int cnt = 0;
            char[] buffer = new char[n];
            string result = "";
            backtrack(0);

            return result;

            void backtrack(int idx)
            {
                if (cnt == k) return;
                if (idx == n)
                {
                    if (++cnt == k) result = new string(buffer);
                    return;
                }

                for (int i = 0; i < 3; i++)
                {
                    buffer[idx] = (char)('a' + i);
                    if (idx == 0 || buffer[idx] != buffer[idx - 1]) backtrack(idx + 1);
                }
            }
        }
    }
}
