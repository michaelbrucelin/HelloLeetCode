using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0936
{
    public class Solution0936 : Interface0936
    {
        /// <summary>
        /// 逆序暴力操作
        /// 正序想有些乱，倒着想就简单多了，逻辑简单了，查找还是暴力查找
        /// 1. 第一轮，将完全匹配的替换为 ???
        /// 2. 下一轮，________???________???________
        ///               s1         s2         s3
        ///    显然，每一个???子串长度都至少是len(stamp)
        ///    s2既有前缀???，又有后缀???，所以，如果s2是stamp的子串，将s2替换为???
        ///    s1与s2有后缀???，所以，如果s1或s2的后缀与stamp的前缀相同，可以将这个后缀替换为???
        ///    s3与s2有前缀???，所以，如果s3或s2的前缀与stamp的后缀相同，可以将这个前缀替换为???
        /// 
        /// 可以沿着这个思路继续，先不写了，有时间再写
        /// </summary>
        /// <param name="stamp"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] MovesToStamp(string stamp, string target)
        {
            if (target[0] != stamp[0] || target[^1] != stamp[^1]) return [];



            List<int> result = [];
            int limit = target.Length * 10;

            if (result.Count > limit) return [];
            result.Reverse();
            return [.. result];
        }
    }
}
