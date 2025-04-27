using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1352
{
    public class Solution1352
    {
    }

    /// <summary>
    /// 后缀积
    /// 类似于前缀和的思想，这里构造后缀积数组
    /// </summary>
    public class ProductOfNumbers : Interface1352
    {
        public ProductOfNumbers()
        {
            nums = [1];
            lastZeroIndex = -1;
        }

        private List<long> nums;
        private int lastZeroIndex;

        public void Add(int num)
        {
            if (num != 0)
            {
                nums.Add(num * nums[^1]);
            }
            else
            {
                nums.Add(1);
                lastZeroIndex = nums.Count - 1;
            }
        }

        public int GetProduct(int k)
        {
            if (nums.Count - k - 1 < lastZeroIndex) return 0;
            return (int)(nums[^1] / nums[nums.Count - k - 1]);
        }
    }
}
