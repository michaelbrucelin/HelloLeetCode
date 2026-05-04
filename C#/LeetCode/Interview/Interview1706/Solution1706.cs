using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1706
{
    public class Solution1706 : Interface1706
    {
        /// <summary>
        /// 数位DP
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumberOf2sInRange(int n)
        {
            List<int> digits = [], cnts1 = [0], cnts2 = [1];
            while (n > 0) { digits.Add(n % 10); n /= 10; }
            int b = 1, len = digits.Count;
            for (int i = 1, x; i < len; i++) { x = digits[i - 1]; cnts1.Add(x * b + cnts1[i - 1]); cnts2.Add(b *= 10); }
            digits.Reverse();
            cnts1.Reverse();
            cnts2.Reverse();

            int[,] memory = new int[len, 2];
            for (int i = 0; i < len; i++) memory[i, 0] = memory[i, 1] = -1;
            return dfs(0, true);

            int dfs(int idx, bool is_limit)
            {
                if (idx == len) return 0;
                int _is_limit = is_limit ? 1 : 0;
                if (memory[idx, _is_limit] != -1) return memory[idx, _is_limit];

                int result = 0, up = is_limit ? digits[idx] : 9;
                if (up > 2) result += cnts2[idx]; else if (up == 2) result += cnts1[idx] + 1;
                for (int i = 0; i <= up; i++)
                {
                    result += dfs(idx + 1, is_limit && i == up);
                }

                memory[idx, _is_limit] = result;
                return result;
            }
        }
    }
}
