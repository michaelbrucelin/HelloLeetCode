using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0047
{
    public class Solution0047 : Interface0047
    {
        /// <summary>
        /// DFS
        /// 逻辑同Solution0046，添加了Hash过滤重复的结果
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            HashSet<string> visited = new HashSet<string>();
            dfs(new List<int>(), nums);

            return result;

            void dfs(List<int> buffer, IList<int> set)
            {
                if (set.Count == 1)
                {
                    buffer.Add(set[0]);
                    string hash = string.Join(',', buffer);
                    if (!visited.Contains(hash))
                    {
                        visited.Add(hash); result.Add(buffer);
                    }
                }
                else
                {
                    int cnt = set.Count;
                    for (int i = 0; i < cnt; i++)
                    {
                        List<int> _buffer = new List<int>(buffer) { set[i] };
                        List<int> _set = new List<int>();
                        for (int j = 0; j < i; j++) _set.Add(set[j]);
                        for (int j = i + 1; j < cnt; j++) _set.Add(set[j]);
                        dfs(_buffer, _set);
                    }
                }
            }
        }
    }
}
