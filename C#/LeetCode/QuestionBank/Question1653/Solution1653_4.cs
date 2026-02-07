using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1653
{
    public class Solution1653_4 : Interface1653
    {
        /// <summary>
        /// 遍历
        /// 遍历每一个位置，删除前面全部的b以及后面全部的a即可，可以使用前缀和思想优化
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinimumDeletions(string s)
        {
            int len = s.Length;
            int[] cnta = new int[len];  // 后缀数组a的数量
            for (int i = len - 2; i >= 0; i--) cnta[i] = cnta[i + 1] + 'b' - s[i + 1];
            int result = cnta[0], cntb = 0;
            for (int i = 1; i < len; i++)
            {
                cntb += s[i - 1] - 'a';
                result = Math.Min(result, cnta[i] + cntb);
            }

            return result;
        }
    }
}
