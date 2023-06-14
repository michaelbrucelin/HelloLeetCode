using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1375
{
    public class Solution1375_2 : Interface1375
    {
        /// <summary>
        /// 排序
        /// 与Solution1375逻辑一样，只是将哈希表改为了排序，写着玩
        /// 由于已知前面的已经排好序了，更好的方式是手写插入排序，这里就不写了，直接调用API
        /// 
        /// 逻辑没问题，提交会超时，参考测试用例03
        /// </summary>
        /// <param name="flips"></param>
        /// <returns></returns>
        public int NumTimesAllBlue2(int[] flips)
        {
            int result = 0, len = flips.Length;
            int[] seq = new int[len];
            for (int i = 0; i < len; i++)
            {
                seq[i] = i + 1;
                Array.Sort(flips, 0, i + 1);
                if (SubSequenceEqual(flips, seq, 0, i + 1)) result++;
            }

            return result;
        }

        /// <summary>
        /// 与NumTimesAllBlue()逻辑一样，优化：
        ///     如果0-n是一个结果，下一次判断从n+1向后判断就可以，不需要继续从0开始
        /// 逻辑没问题，没有提交测试，目测依然会超时
        /// </summary>
        /// <param name="flips"></param>
        /// <returns></returns>
        public int NumTimesAllBlue(int[] flips)
        {
            int result = 0, start = 0, len = flips.Length;
            int[] seq = new int[len];
            for (int i = 0; i < len; i++)
            {
                seq[i] = i + 1;
                Array.Sort(flips, start, i - start + 1);
                if (SubSequenceEqual(flips, seq, start, i - start + 1))
                {
                    result++; start = i + 1;
                }
            }

            return result;
        }

        private bool SubSequenceEqual(int[] arr1, int[] arr2, int start, int len)
        {
            for (int i = start; i < start + len; i++)
            {
                if (arr1[i] != arr2[i]) return false;
            }
            return true;
        }
    }
}
