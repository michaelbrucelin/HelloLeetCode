using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1389
{
    public class Solution1389 : Interface1389
    {
        /// <summary>
        /// 模拟
        /// 本质上就是插入排序
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public int[] CreateTargetArray(int[] nums, int[] index)
        {
            int len = nums.Length;
            int[] result = new int[len];
            for (int i = 0, id; i < len; i++)
            {
                id = index[i];
                if (id < i) for (int j = i; j > id; j--)
                    {
                        result[j] = result[j - 1];
                    }
                result[id] = nums[i];
            }

            return result;
        }

        /// <summary>
        /// 模拟
        /// 与CreateTargetArray()逻辑一样，原地操作
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public int[] CreateTargetArray2(int[] nums, int[] index)
        {
            int len = nums.Length;
            for (int i = 0, id, num; i < len; i++)
            {
                id = index[i]; num = nums[i];
                if (id < i) for (int j = i; j > id; j--)
                    {
                        nums[j] = nums[j - 1];
                    }
                nums[id] = num;
            }

            return nums;
        }
    }
}
