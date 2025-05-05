using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0838
{
    public class Solution0838_2 : Interface0838
    {
        /// <summary>
        /// 模拟，双指针
        /// 从左向右找不是 . 的位置，
        ///     如果是 L，左侧全部更新为 L
        ///     如果是 R，
        ///         如果右侧下一个是 R，二者之间全部更新为 R
        ///         如果右侧下一个是 L，从两侧向中间更新
        /// </summary>
        /// <param name="dominoes"></param>
        /// <returns></returns>
        public string PushDominoes(string dominoes)
        {
            if (dominoes.Length == 1) return dominoes;

            char[] chars = dominoes.ToCharArray();
            int pl = 0, pr = -1, len = chars.Length;
            while (pl < len)
            {
                while (pl < len && chars[pl] == '.') pl++;
                if (pl == len) break;
                if (chars[pl] == 'L')
                {
                    for (int i = pl - 1; i > pr; i--) chars[i] = 'L';
                    pr = pl++;
                }
                else  // if (chars[pl] == 'R')
                {
                    while (pl < len && chars[pl] == 'R')
                    {
                        pr = pl + 1;
                        while (pr < len && chars[pr] == '.') pr++;
                        if (pr == len || chars[pr] == 'R')
                        {
                            for (int i = pr - 1; i > pl; i--) chars[i] = 'R';
                            pl = pr;
                        }
                        else
                        {
                            for (int i = pl + 1, j = pr - 1; i < j; i++, j--) { chars[i] = 'R'; chars[j] = 'L'; }
                            pl = pr + 1;
                        }
                    }
                }
            }

            return new string(chars);
        }
    }
}
