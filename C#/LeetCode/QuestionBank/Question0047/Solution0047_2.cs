using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0047
{
    public class Solution0047_2 : Interface0047
    {
        /// <summary>
        /// 回溯
        /// 逻辑同Solution0046_2，添加了Hash过滤重复的结果
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            HashSet<string> visited = new HashSet<string>();
            int cnt = nums.Length;
            bool[] mask = new bool[cnt];
            backtrack(new List<int>());

            return result;

            void backtrack(List<int> buffer)
            {
                if (buffer.Count == cnt)
                {
                    string hash = string.Join(',', buffer);
                    if (!visited.Contains(hash))
                    {
                        visited.Add(hash); result.Add(buffer);
                    }
                }
                else
                {
                    for (int i = 0; i < cnt; i++) if (!mask[i])
                        {
                            List<int> _buffer = new List<int>(buffer) { nums[i] };
                            mask[i] = true;
                            backtrack(_buffer);
                            mask[i] = false;
                        }
                }
            }
        }
    }
}
