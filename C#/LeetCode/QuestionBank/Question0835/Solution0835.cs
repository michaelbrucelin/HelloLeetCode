using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0835
{
    public class Solution0835 : Interface0835
    {
        /// <summary>
        /// 暴力枚举
        /// 就是一个映射关系，在纸上画画就好了
        /// </summary>
        /// <param name="img1"></param>
        /// <param name="img2"></param>
        /// <returns></returns>
        public int LargestOverlap(int[][] img1, int[][] img2)
        {
            int result = 0, _result, r1, c1, r2, c2, rcnt, ccnt, n = img1.Length;
            for (int ri = -n + 1; ri < n; ri++) for (int ci = -n + 1; ci < n; ci++)  // ri, ci: offset
                {
                    rcnt = n - Math.Abs(ri); ccnt = n - Math.Abs(ci);
                    r1 = Math.Max(-ri, 0); c1 = Math.Max(-ci, 0);
                    r2 = Math.Max(+ri, 0); c2 = Math.Max(+ci, 0);
                    _result = 0;
                    for (int i = 0; i < rcnt; i++) for (int j = 0; j < ccnt; j++)
                        {
                            _result += img1[r1 + i][c1 + j] & img2[r2 + i][c2 + j];
                        }
                    result = Math.Max(result, _result);
                }

            return result;
        }
    }
}
