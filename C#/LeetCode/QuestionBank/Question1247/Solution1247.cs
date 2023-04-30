using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1247
{
    public class Solution1247 : Interface1247
    {
        /// <summary>
        /// 贪心
        /// 1. 首先如果对应位置的字符相同，一定不参与交换，反证法可以证明这个结论
        /// 2. 一定有偶数个位置字符不同，否则无法交换成功，同样反证法可以证明这个结论
        ///     偶数个位置字符不同，一定可以交换成功，参考第3条结论
        /// 3. 两个位置都不同，共2中情况
        ///     情况1：x x    情况2：x y    y y 与 y x 是前两种情况的镜像，忽略
        ///            y y           y x    x x    x y
        ///     情况1只需要一次交换就可以达成目标，情况2需要两次交换才可以达成目标
        /// 4. 所以优先处理情况1，然后处理情况2
        /// 
        /// 例如
        ///          0123456789  不同的位  1 3 4 5 7 8
        ///     s1 = xxyyxyxyxx            x y x y y x
        ///     s2 = xyyxyxxxyx            y x y x x y
        ///     凑齐1对x x，需要1次交换，凑齐1对y y，需要1次交换，凑齐1对x y，需要2次交换，所以结果为4
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public int MinimumSwap(string s1, string s2)
        {
            int len = s1.Length, diff_x = 0, diff_y = 0;
            for (int i = 0; i < len; i++)
            {
                switch ((s1[i], s2[i]))
                {
                    case ('x', 'y'): diff_x++; break;
                    case ('y', 'x'): diff_y++; break;
                    default: break;
                }
            }

            if (((diff_x + diff_y) & 1) != 0) return -1;
            // diff_x与diff_y同为偶数或同为奇数
            return (diff_x >> 1) + (diff_y >> 1) + ((diff_x & 1) != 1 ? 0 : 2);
        }
    }
}
