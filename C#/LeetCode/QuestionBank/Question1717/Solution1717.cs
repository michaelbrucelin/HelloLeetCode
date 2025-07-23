using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1717
{
    public class Solution1717 : Interface1717
    {
        /// <summary>
        /// 贪心
        /// 如果 x==y，则随便操作
        /// 如果 x!=y，则有分高的操作分高的，没有分高的，操作分低的
        ///     简单证明
        ///     假设 x > y，则 x-y >= 1，而一段连续的ab交错的字串中，ab与ba的数量最多差一个，所以操作分高的，没错
        ///     当全部的ab都删除之后（反复多次），再删除全部的ba（反复多次）
        ///     需要证明的是删除是无序的，想象成栈，删除的确是无序的
        /// 还是没想清楚证明过程，直觉上这样是对的...先把代码写出来
        /// 
        /// 提交通过了......
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int MaximumGain(string s, int x, int y)
        {
            (string str, int score)[] infos;
            if (x >= y) infos = [("ab", x), ("ba", y)]; else infos = [("ba", y), ("ab", x)];
            int result = 0, len;
            foreach (var info in infos) while (s.Contains(info.str))
                {
                    len = s.Length;
                    s = s.Replace(info.str, "");
                    result += ((len - s.Length) >> 1) * info.score;
                }

            return result;
        }
    }
}
