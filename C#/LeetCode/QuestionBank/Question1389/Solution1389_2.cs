using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1389
{
    public class Solution1389_2 : Interface1389
    {
        /// <summary>
        /// 分析
        /// 1. 预处理index[]为真实的index
        ///     从前向后遍历index数组，如果第i项的值小于i，那么前面所有大于等于i的项加1即可
        /// 细想一下，本质上依然是插入排序，但是将“移动”操作改为了index调整
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public int[] CreateTargetArray(int[] nums, int[] index)
        {
            int len = nums.Length;
            for (int i = 0; i < len; i++) if (index[i] < i) for (int j = 0; j < i; j++)
                    {
                        if (index[j] >= index[i]) index[j]++;
                    }

            int[] result = new int[len];
            for (int i = 0; i < len; i++) result[index[i]] = nums[i];

            return result;
        }

        /// <summary>
        /// 排序
        /// 与CreateTargetArray()一样，既然已经得出了正确的index数组，那么直接按照index数组排序即可
        /// 时间复杂度降低了，只是写着玩，而且可以降低空间复杂度
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public int[] CreateTargetArray2(int[] nums, int[] index)
        {
            int len = nums.Length;
            for (int i = 0; i < len; i++) if (index[i] < i) for (int j = 0; j < i; j++)
                    {
                        if (index[j] >= index[i]) index[j]++;
                    }

            return nums.Zip(index, (num, id) => (num, id))
                       .OrderBy(t => t.id)
                       .Select(t => t.num)
                       .ToArray();
        }
    }
}
