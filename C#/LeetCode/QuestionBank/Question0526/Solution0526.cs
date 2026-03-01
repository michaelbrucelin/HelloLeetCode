using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0526
{
    public class Solution0526 : Interface0526
    {
        /// <summary>
        /// 回溯
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountArrangement(int n)
        {
            int result = 0;
            bool[] mask = new bool[n];
            backtrack(0);

            return result;

            void backtrack(int cnt)
            {
                if (cnt == n) result++;

                for (int i = 0; i < n; i++) if (!mask[i] && ((i + 1) % (cnt + 1) == 0 || (cnt + 1) % (i + 1) == 0))
                    {
                        mask[i] = true;
                        backtrack(cnt + 1);
                        mask[i] = false;
                    }
            }
        }
    }
}
