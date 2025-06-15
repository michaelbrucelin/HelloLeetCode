using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2616
{
    public class Solution2616_err : Interface2616
    {
        /// <summary>
        /// 贪心，构造
        /// 1. 排序
        /// 2. 计算相邻元素的差值，长度为 n - 1 的数组，diff
        /// 3. 将diff排序，并记录每个元素排序前的索引
        /// 4. 从小到大从diff中取值，并保证没有“原序”中相邻的元素
        /// 
        /// 逻辑错误，参考测试用例04
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public int MinimizeMax(int[] nums, int p)
        {
            if (p == 0 || nums.Length < 2) return 0;

            Array.Sort(nums);
            int len = nums.Length;
            int[] diff = new int[len - 1];
            for (int i = 1; i < len; i++) diff[i - 1] = nums[i] - nums[i - 1];
            var sortdiff = diff.Select((val, id) => (val, id)).OrderBy(x => x.val).ToArray();

            int ptr = -1, cnt = 0;
            bool[] mask = new bool[--len];
            while (cnt < p)
            {
                ptr++;
                if (!((sortdiff[ptr].id - 1 >= 0 && mask[sortdiff[ptr].id - 1]) || (sortdiff[ptr].id + 1 < len && mask[sortdiff[ptr].id + 1])))
                {
                    cnt++; mask[sortdiff[ptr].id] = true;
                }
            }

            return sortdiff[ptr].val;
        }
    }
}
