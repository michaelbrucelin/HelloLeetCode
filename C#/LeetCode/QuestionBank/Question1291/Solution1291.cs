using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1291
{
    public class Solution1291 : Interface1291
    {
        /// <summary>
        /// 数位DP
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public IList<int> SequentialDigits(int low, int high)
        {
            List<int> llist = digitdp(low - 1);
            List<int> hlist = digitdp(high);
            // return hlist[llist.Count..].Order().ToList();
            return hlist[llist.Count..].ToList();

            List<int> digitdp(int x)
            {
                List<int> result = [];
                List<int> digits = [];
                while (x > 0) { digits.Add(x % 10); x /= 10; }
                digits.Reverse();
                dfs(0, digits, true, true, 0, result);

                return result;
            }

            void dfs(int curr, List<int> digits, bool isprefix, bool iszero, int len, List<int> result)
            {
                if (len == digits.Count) { result.Add(curr); return; }
                if (isprefix)
                {
                    if (iszero)
                    {
                        dfs(0, digits, false, true, len + 1, result);
                        for (int i = 1; i < digits[len]; i++) dfs(i, digits, false, false, len + 1, result);
                        dfs(digits[len], digits, true, false, len + 1, result);
                    }
                    else
                    {
                        int x = curr % 10 + 1;
                        if (x <= digits[len]) dfs(curr * 10 + x, digits, x == digits[len], false, len + 1, result);
                    }
                }
                else
                {
                    if (iszero)
                    {
                        dfs(0, digits, false, true, len + 1, result);
                        for (int i = 1; i < 10; i++) dfs(i, digits, false, false, len + 1, result);
                    }
                    else
                    {
                        int x = curr % 10 + 1;
                        if (x < 10) dfs(curr * 10 + x, digits, false, false, len + 1, result);
                    }
                }
            }
        }
    }
}
