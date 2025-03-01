using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0131
{
    public class Solution0131_3 : Interface0131
    {
        /// <summary>
        /// dfs + 记忆化搜索
        /// 逻辑同Solution0131_2，将字串的结果也添加了记忆化搜索
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<IList<string>> Partition(string s)
        {
            int len = s.Length;
            bool?[,] checks = new bool?[len, len];
            IList<IList<string>>[] memory = new IList<IList<string>>[len];
            return dfs(0);

            IList<IList<string>> dfs(int l)
            {
                if (l == len - 1) return new List<IList<string>> { new List<string> { s[l..] } };
                if (memory[l] != null) return memory[l];

                IList<IList<string>> result = new List<IList<string>>();
                for (int r = l; r < len; r++)
                {
                    if (checks[l, r] == null) checks[l, r] = check(l, r);
                    if ((bool)checks[l, r])
                    {
                        if (r == len - 1)
                        {
                            result.Add(new List<string> { s[l..] });
                        }
                        else
                        {
                            IList<IList<string>> _result = dfs(r + 1);
                            if (_result.Count > 0)
                            {
                                string str = s[l..(r + 1)];
                                foreach (var list in _result) result.Add([str, .. list]);
                            }
                        }
                    }
                }
                memory[l] = result;

                return result;
            }

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
