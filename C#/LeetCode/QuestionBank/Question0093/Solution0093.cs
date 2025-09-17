using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0093
{
    public class Solution0093 : Interface0093
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> RestoreIpAddresses(string s)
        {
            List<string> result = new List<string>();
            int len = s.Length;
            if (len < 4 || len > 12) return result;
            dfs(0, 3, []);

            return result;

            void dfs(int start, int todo, List<string> list)
            {
                if (len - start < todo + 1 || len - start > todo * 3 + 3) return;
                if (todo > 0)
                {
                    if (s[start] != '0')
                    {
                        if (start < len - 1)
                        {
                            List<string> _list = [.. list, s[start..(start + 2)]];  // new List<string>(list) { s[start..(start + 2)] };
                            dfs(start + 2, todo - 1, _list);
                            if (start < len - 2 && int.Parse(s[start..(start + 3)]) <= 255)
                            {
                                List<string> __list = [.. list, s[start..(start + 3)]];
                                dfs(start + 3, todo - 1, __list);
                            }
                        }

                    }
                    list.Add(s[start].ToString());
                    dfs(start + 1, todo - 1, list);
                }
                else
                {
                    if ((s[start] == '0' && start < len - 1) || (int.Parse(s[start..len]) > 255)) return;
                    list.Add(s[start..len]);
                    result.Add(string.Join('.', list));
                }
            }
        }
    }
}
