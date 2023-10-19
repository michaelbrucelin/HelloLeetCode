using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1726
{
    public class Solution1726 : Interface1726
    {
        /// <summary>
        /// 暴力枚举
        /// 题目限定了数组中所有元素都不同，那么遍历每一种组合放字典中计数即可
        /// 
        /// 提交竟然过了，而且是双百... ...，那为何是中等难度？
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int TupleSameProduct(int[] nums)
        {
            Dictionary<int, int> cache = new Dictionary<int, int>();
            int pro, len = nums.Length;
            for (int i = 0; i < len - 1; i++) for (int j = i + 1; j < len; j++)
                {
                    pro = nums[i] * nums[j];
                    if (cache.ContainsKey(pro)) cache[pro]++; else cache.Add(pro, 1);
                }

            int result = 0;
            foreach (int cnt in cache.Values) result += cnt * (cnt - 1) << 2;  // if (cnt > 1)
            return result;
        }
    }
}
