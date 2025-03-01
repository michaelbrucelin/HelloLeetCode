using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0131
{
    /// <summary>
    /// DP，BFS
    /// Solution0131_err纠正的解法
    /// </summary>
    public class Solution0131_4 : Interface0131
    {
        public IList<IList<string>> Partition(string s)
        {
            int len = s.Length;
            IList<IList<string>>[] dp = new IList<IList<string>>[len];
            dp[0] = new List<IList<string>> { new List<string> { s[0..1] } };

            for (int r = 1; r < len; r++)
            {
                dp[r] = new List<IList<string>>();
                for (int l = r; l >= 0; l--) if (check(l, r))
                    {
                        if (l == 0)
                        {
                            dp[r].Add([s[0..(r + 1)]]);
                        }
                        else
                        {
                            foreach (var list in dp[l - 1])
                            {
                                List<string> _list = [.. list];
                                _list.Add(s[l..(r + 1)]);
                                dp[r].Add(_list);
                            }
                        }
                    }
            }

            return dp[len - 1];

            bool check(int l, int r)
            {
                while (l < r)
                {
                    if (s[l] != s[r]) return false;
                    l++;
                    r--;
                }

                return true;
            }
        }
    }
}
