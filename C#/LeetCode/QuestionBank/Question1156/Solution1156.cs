using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1156
{
    public class Solution1156 : Interface1156
    {
        /// <summary>
        /// 分析
        /// 1. 预处理字符串每个字符的数量极其分布情况
        ///     例如："aaabbaaa" --> a:6, [0,2], [5,7]
        ///                          b:2, [3,4]
        /// 2. 先处理两种特殊情况
        ///     如果字符串只有1种字符，那么直接返回整个字符串的长度
        ///     如果字符串只有2种字符，且其中的1种字符只有一个，那么直接返回整个字符串的长度-1
        /// 3. 从前向后遍历字符串，遍历到任何一个字符（这里假定是x），可以快速的知道字符串中x的数量cnt，以及当前位置连续的x的数量cnt1，区间为[l, r]
        ///     如果cnt1 = cnt，那么调整后仍然是cnt1
        ///     如果cnt1 < cnt
        ///         如果调整左侧，如果str[l-2] != x，调整后为cnt1+1
        ///                       如果str[l-2] =  x，那么str[l-2]属于x的前一个连续区间，假定x的数量为cnt2
        ///                           如果cnt1 + cnt2 != cnt，调整后为cnt1+cnt2
        ///                           如果cnt1 + cnt2 =  cnt，调整后为cnt1+cnt2-1
        ///         如果调整右侧，如果str[r+2] != x，调整后为cnt1+1
        ///                       如果str[r+2] =  x，那么str[r+2]属于x的后一个连续区间，假定x的数量为cnt2
        ///                           如果cnt1 + cnt2 != cnt，调整后为cnt1+cnt2
        ///                           如果cnt1 + cnt2 =  cnt，调整后为cnt1+cnt2-1
        ///     取上面几个值的最大值，就是此次调整后的最大值
        /// 4. 特殊情况不需要单独处理
        /// 优化
        /// 1. 预处理中的分布，不需要按照字符记录，整体记录就可以
        ///     例如："aaabbaaa" --> a:6, b:2, [0,2], [3,4], [5,7]
        /// 2. 上面第3步的遍历，不需要遍历字符串中的字符，直接遍历分布列表就可以了
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int MaxRepOpt1(string text)
        {
            throw new NotImplementedException();
        }
    }
}
