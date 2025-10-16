using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2598
{
    public class Solution2598 : Interface2598
    {
        /// <summary>
        /// 对模分组
        /// 将nums中的值按照对value取余的结果分组，假定数量最少的数目是x
        /// 则[0..value*x-1]，可以凑全，那么分析[value*x..value*x+value-1]中即可
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int FindSmallestInteger(int[] nums, int value)
        {
            int[] freq = new int[value];
            foreach (int num in nums) freq[(num % value + value) % value]++;
            int minid = 0, maxid = 0;
            for (int i = 0; i < value; i++)
            {
                if (freq[i] == 0) return i;
                if (freq[i] < freq[minid]) minid = i; else if (freq[i] >= freq[maxid]) maxid = i;
            }

            // return freq[maxid] == freq[minid] ? (value * freq[minid]) : (value * freq[minid]) + minid;
            return (value * freq[minid]) + minid;
        }
    }
}
