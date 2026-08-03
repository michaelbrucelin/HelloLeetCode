using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3955
{
    public class Solution3955 : Interface3955
    {
        /// <summary>
        /// 枚举
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<string> GenerateValidStrings(int n, int k)
        {
            int N = 1 << n;
            List<string> result = [];
            string s;
            for (int i = 0; i < N; i++)
            {
                s = Convert.ToString(i, 2).PadLeft(n, '0');
                if (check(s, n, k)) result.Add(s);
            }

            return result;

            static bool check(string s, int n, int k)
            {
                int _k = 0;
                for (int i = 0; i < n; i++) if (s[i] != '0')
                    {
                        if ((_k += i) > k) return false;
                        if (i > 0 && s[i - 1] != '0') return false;
                    }

                return true;
            }
        }
    }
}
