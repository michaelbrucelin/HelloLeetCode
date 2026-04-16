using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3488
{
    public class Solution3488_2 : Interface3488
    {
        /// <summary>
        /// 预处理
        /// 预处理左侧及右侧最近相同元素的位置，以及每个元素第一次以及最后依次出现的位置
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public IList<int> SolveQueries(int[] nums, int[] queries)
        {
            int lenn = nums.Length, lenq = queries.Length;
            int[] lnum = new int[lenn], rnum = new int[lenn];
            Dictionary<int, int> lmap = [], rmap = [], map = [];
            for (int i = 0, num; i < lenn; i++)
            {
                num = nums[i];
                if (map.TryGetValue(num, out int idx)) { lnum[i] = idx; map[num] = i; } else { lmap.Add(num, i); lnum[i] = -1; map.Add(num, i); }
            }
            map.Clear();
            for (int i = lenn - 1, num; i >= 0; i--)
            {
                num = nums[i];
                if (map.TryGetValue(num, out int idx)) { rnum[i] = idx; map[num] = i; } else { rmap.Add(num, i); rnum[i] = lenn; map.Add(num, i); }
            }

            int[] result = new int[lenq];
            for (int i = 0, j; i < lenq; i++)
            {
                j = queries[i];
                switch ((lnum[j] + 1, rnum[j] - lenn))
                {
                    case (0, 0): result[i] = -1; break;
                    case (0, _): result[i] = Math.Min(rnum[j] - j, j + lenn - rmap[nums[j]]); break;
                    case (_, 0): result[i] = Math.Min(j - lnum[j], lmap[nums[j]] + lenn - j); break;
                    default: result[i] = Math.Min(j - lnum[j], rnum[j] - j); break;
                }
            }

            return result;
        }
    }
}
