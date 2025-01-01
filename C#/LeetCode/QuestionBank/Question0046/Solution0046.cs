using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0046
{
    public class Solution0046 : Interface0046
    {
        /// <summary>
        /// DFS
        /// 模拟N*(N-1)*(N-2)*...*2*1的过程
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            dfs(new List<int>(), nums);

            return result;

            void dfs(List<int> buffer, IList<int> set)
            {
                if (set.Count == 1)
                {
                    buffer.Add(set[0]); result.Add(buffer);
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
