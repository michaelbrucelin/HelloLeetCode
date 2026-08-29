using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2948
{
    public class Solution2948 : Interface2948
    {

        /// <summary>
        /// 分组 + 每组组内排序
        /// 每一组记录：索引及边界，边界即：[min-limit, max+limit]
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int[] LexicographicallySmallestArray(int[] nums, int limit)
        {
            int len = nums.Length;
            int[] idxs = new int[len];
            for (int i = 0; i < len; i++) idxs[i] = i;
            Array.Sort(idxs, (x, y) => nums[x] - nums[y]);

            int[] result = new int[len], _idxs = [.. idxs];
            int pl = 0, pr = 0;
            while (++pr < len)
            {
                if (nums[idxs[pr]] - nums[idxs[pr - 1]] <= limit) continue;
                Array.Sort(_idxs, pl, pr - pl);
                for (int i = pl; i < pr; i++) result[_idxs[i]] = nums[idxs[i]];
                pl = pr;
            }
            Array.Sort(_idxs, pl, pr - pl);
            for (int i = pl; i < pr; i++) result[_idxs[i]] = nums[idxs[i]];

            return result;
        }
    }
}
