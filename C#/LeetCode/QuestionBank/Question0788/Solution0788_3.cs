using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0788
{
    public class Solution0788_3 : Interface0788
    {
        private static readonly int[] digits_true = [2, 5, 6, 9];
        private static readonly int[] digits_false = [0, 1, 8,];

        /// <summary>
        /// 数位DP
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int RotatedDigits(int n)
        {
            List<int> digits = [];
            while (n > 0) { digits.Add(n % 10); n /= 10; }
            digits.Reverse();

            int len = digits.Count;
            int[,,] memory = new int[len, 2, 2];
            for (int i = 0; i < len; i++) memory[i, 0, 0] = memory[i, 0, 1] = memory[i, 1, 0] = memory[i, 1, 1] = -1;
            return dfs(0, true, false);

            int dfs(int idx, bool is_limit, bool is_true)  // is_limit表示前i位是否与n相同, is_true表示包含2 5 6 9
            {
                if (idx == len) return is_true ? 1 : 0;
                int _is_limit = is_limit ? 1 : 0, _is_true = is_true ? 1 : 0;
                if (memory[idx, _is_limit, _is_true] != -1) return memory[idx, _is_limit, _is_true];

                int result = 0, up = is_limit ? digits[idx] : 9;
                for (int i = 0; i < 4 && digits_true[i] <= up; i++) result += dfs(idx + 1, is_limit && digits_true[i] == digits[idx], true);
                for (int i = 0; i < 3 && digits_false[i] <= up; i++) result += dfs(idx + 1, is_limit && digits_false[i] == digits[idx], is_true);
                memory[idx, _is_limit, _is_true] = result;
                return result;
            }
        }
    }
}
