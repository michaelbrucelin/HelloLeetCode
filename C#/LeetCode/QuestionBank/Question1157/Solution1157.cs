using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1157
{
    public class Solution1157
    {
    }

    /// <summary>
    /// 暴力解法
    /// 使用摩尔投票法，提交会超时，没有显示测试用例的具体数据
    /// 使用哈希计数法，提交会超时，更慢，参考测试用例04
    /// </summary>
    public class MajorityChecker : Interface1157
    {
        public MajorityChecker(int[] arr)
        {
            this.arr = arr;
        }

        private int[] arr;

        #region 摩尔投票，提交会超时
        /// <summary>
        /// 摩尔投票，提交会超时
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        //public int Query(int left, int right, int threshold)
        //{
        //    int pre = arr[left], cnt = 1;
        //    for (int i = left + 1; i <= right; i++)
        //    {
        //        if (cnt == 0)
        //        {
        //            pre = arr[i]; cnt = 1;
        //        }
        //        else
        //        {
        //            if (arr[i] == pre) cnt++; else cnt--;
        //        }
        //    }
        //    if (cnt >= threshold) return pre;

        //    cnt = 0;
        //    for (int i = left; i <= right; i++) if (arr[i] == pre) cnt++;
        //    if (cnt >= threshold) return pre;

        //    return -1;
        //}
        #endregion

        #region Hash计数，提交会超时
        /// <summary>
        /// Hash计数，提交会超时
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public int Query(int left, int right, int threshold)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            for (int i = left; i <= right; i++)
                if (freq.ContainsKey(arr[i])) freq[arr[i]]++; else freq.Add(arr[i], 1);

            int num = -1, cnt = 0;
            foreach (var kv in freq)
            {
                if (kv.Value > cnt)
                {
                    num = kv.Key; cnt = kv.Value;
                }
            }

            return cnt >= threshold ? num : -1;
        }
        #endregion
    }
}
