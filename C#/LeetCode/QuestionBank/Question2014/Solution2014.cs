using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2014
{
    public class Solution2014 : Interface2014
    {
        /// <summary>
        /// 二分 + 贪心
        /// 1. 预处理出每个字母的出现位置，并剔除数量不足k的字母
        /// 2. 最小的字符串（可能）为a，最大的字符串（可能）为zzz，其中z的数量为字母次数和/k
        /// 3. 然后把小写字母组成的字符串当成26进制数字来处理，使用二分查找来确定最长的字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string LongestSubsequenceRepeatedK(string s, int k)
        {
            throw new NotImplementedException();
        }
    }
}
