using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0046
{
    public class Solution0046_2 : Interface0046
    {
        /// <summary>
        /// 回溯
        /// 逻辑同Solution0046，通过回溯优化空间复杂度
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            int cnt = nums.Length;
            bool[] mask = new bool[cnt];
            backtrack(new List<int>());

            return result;

            void backtrack(List<int> buffer)
            {
                if (buffer.Count == cnt)
                {
                    result.Add(buffer);
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
