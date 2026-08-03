using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3955
{
    public class Solution3955_2 : Interface3955
    {
        /// <summary>
        /// 回溯
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<string> GenerateValidStrings(int n, int k)
        {
            List<string> result = [];
            char[] chars = new char[n];
            backtrack(0, 0);
            return result;

            void backtrack(int point, int idx)
            {
                if (idx == n) { result.Add(new string(chars)); return; }

                chars[idx] = '0';
                backtrack(point, idx + 1);
                if ((idx == 0 || chars[idx - 1] != '1') && point + idx <= k)
                {
                    chars[idx] = '1';
                    backtrack(point + idx, idx + 1);
                }
            }
        }

        public IList<string> GenerateValidStrings2(int n, int k)
        {
            List<string> result = [];
            char[] chars = new char[n];
            backtrack(result, 0, 0, n, k, chars);
            return result;

            static void backtrack(List<string> list, int point, int idx, int n, int k, char[] chars)
            {
                if (idx == n) { list.Add(new string(chars)); return; }

                chars[idx] = '0';
                backtrack(list, point, idx + 1, n, k, chars);
                if ((idx == 0 || chars[idx - 1] != '1') && point + idx <= k)
                {
                    chars[idx] = '1';
                    backtrack(list, point + idx, idx + 1, n, k, chars);
                }
            }
        }
    }
}
