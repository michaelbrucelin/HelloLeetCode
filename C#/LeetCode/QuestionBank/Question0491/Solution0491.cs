using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0491
{
    public class Solution0491 : Interface0491
    {
        /// <summary>
        /// 二进制枚举 + Hash
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> FindSubsequences(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            HashSet<string> set = new HashSet<string>();
            int N = 1 << nums.Length;
            StringBuilder buffer = new StringBuilder();
            List<int> list = [];
            for (int x = 1, _x, pos; x < N; x++)
            {
                pos = 0; _x = x; list.Clear(); buffer.Clear();
                while (_x > 0)
                {
                    if ((_x & 1) != 0) { list.Add(nums[pos]); buffer.Append($"-{nums[pos]}"); }
                    _x >>= 1;
                    pos++;
                }
                if (list.Count > 1)
                {
                    for (int i = 1, cnt = list.Count; i < cnt; i++) if (list[i] < list[i - 1]) goto CONTINUE;
                    if (set.Add(buffer.ToString())) result.Add([.. list]);
                }
            CONTINUE:;
            }

            return result;
        }
    }
}
