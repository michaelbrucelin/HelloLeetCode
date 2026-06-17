using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1081
{
    public class Solution1081_err : Interface1081
    {
        /// <summary>
        /// 贪心 + 预处理
        /// 先确定a的位置，然后确定b的位置，...最后确定z的位置
        /// 假定确定了b的位置，是idx，现在该确定c的位置了
        ///     如果存在一个c的位置：IDX，满足 IDX > idx 且 s[IDX+1..] 包含全部的 d-z，选则满足这个条件的最小的IDX，然后 idx = IDX
        ///     否则选择满足 IDX > idx 的最小的 IDX，然后 idx 不变
        /// 为了优化上面的判断过程，可以提前预处理出每个字符在s中出现的位置及当前位置后面是否还有这个字符
        /// 
        /// 思路是错的，所以没写完，例如 axyzcbcbcb，按照上面思路，结果是 axyzcb，而正确结果是 axyzbc
        /// 可以通过分治优化，选择了第一个b后，分治前面的子串，分治后面的子串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string SmallestSubsequence(string s)
        {
            if (s.Length == 1) return s;

            int len = s.Length;
            List<int>[] idxs = new List<int>[26];
            for (int i = 0; i < 26; i++) idxs[i] = [];
            bool[,] suffix = new bool[len + 1, 26];
            for (int i = len, j; i >= 0; i--)
            {
                idxs[j = s[i] - 'a'].Add(i);
                for (int k = 0; k < 26; k++) suffix[i, k] = k == j ? true : suffix[i + 1, k];
            }
            for (int i = 0; i < 26; i++) idxs.Reverse();

            StringBuilder result = new StringBuilder();
            int left = -1;
            for (int i = 0; i < 26; i++) if (suffix[0, i])
                {

                }

            return result.ToString();
        }
    }
}
