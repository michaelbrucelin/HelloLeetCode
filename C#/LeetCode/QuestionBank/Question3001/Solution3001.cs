using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3001
{
    public class Solution3001 : Interface3001
    {
        /// <summary>
        /// 脑筋急转弯，分类讨论
        /// 如果不能1步搞定，那么两步必然能够搞定。
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public int MinMovesToCaptureTheQueen(int a, int b, int c, int d, int e, int f)
        {
            if (a == e)
            {
                if (a != c) return 1;
                if ((b - d) * (f - d) > 0) return 1;
            }
            if (b == f)
            {
                if (b != d) return 1;
                if ((a - c) * (e - c) > 0) return 1;
            }
            if (c - d == e - f)
            {
                if (c - d != a - b) return 1;
                if ((c - a) * (e - a) > 0) return 1;
            }
            if (c + d == e + f)
            {
                if (c + d != a + b) return 1;
                if ((c - a) * (e - a) > 0) return 1;
            }

            return 2;
        }
    }
}
