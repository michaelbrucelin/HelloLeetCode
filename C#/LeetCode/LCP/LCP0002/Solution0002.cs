using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0002
{
    public class Solution0002 : Interface0002
    {
        /// <summary>
        /// 遍历
        /// 从后向前遍历即可
        /// </summary>
        /// <param name="cont"></param>
        /// <returns></returns>
        public int[] fraction(int[] cont)
        {
            int x = 1, y = cont[^1];  // x/y
            for (int i = cont.Length - 2; i >= 0; i--)
            {
                (x, y) = (y, cont[i] * y + x);
            }

            return [y, x];
        }

        /// <summary>
        /// 题目没有C#模板，需要写java兼容代码，使用java提交
        /// </summary>
        /// <param name="cont"></param>
        /// <returns></returns>
        public int[] fraction_java(int[] cont)
        {
            int x = 1;
            int y = cont[cont.Length - 1];  // x/y, Length需要改为length
            for (int i = cont.Length - 2, t; i >= 0; i--)
            {
                t = cont[i] * y + x;
                x = y;
                y = t;
            }

            return new int[] { y, x };
        }
    }
}
