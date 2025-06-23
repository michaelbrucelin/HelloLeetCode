using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2081
{
    public class Solution2081 : Interface2081
    {
        /// <summary>
        /// 递推
        /// 递推获取每一个镜像的十进制，然后验证是否是k进制的镜像数
        /// 怎样递推
        /// 1. 第一个镜像数是1
        /// 2. 用List<int> 存储十进制数字的每一位，从中间向两边扩展，从0到9
        ///     例如[ 1 0 0 0 1] -> [ 1 0 1 0 1] -> ... -> [ 1 0 9 0 1] -> [ 1 1 0 1 9]
        /// 3. 如果List<int>中全部数字是9，下一个镜像数：
        ///     list长度增加1，两端为1，中间为0，即999...9 + 2
        /// </summary>
        /// <param name="k"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public long KMirror(int k, int n)
        {
            List<int> mirror = new();

            long result = 0, num, cnt = 0;
            while (cnt < n)
            {
                GetNextMirrorNum();
                num = 0;
                foreach (int x in mirror) num = num * 10 + x;
                if (IsKMirror(num))
                {
                    result += num; cnt++;
                }
            }

            return result;

            // 获取下一个10进制的镜像数
            void GetNextMirrorNum()
            {
                if (mirror.Count == 0)
                {
                    mirror.Add(1);
                }
                else
                {
                    if (mirror.All(x => x == 9))
                    {
                        mirror[0] = 1;
                        for (int i = 1; i < mirror.Count; i++) mirror[i] = 0;
                        mirror.Add(1);
                    }
                    else
                    {
                        int p1 = (mirror.Count - 1) >> 1, p2 = mirror.Count >> 1;
                        while (p1 >= 0)
                        {
                            if (mirror[p1] != 9)
                            {
                                mirror[p1]++; if (p2 != p1) mirror[p2]++; break;
                            }
                            else
                            {
                                mirror[p1] = mirror[p2] = 0;
                            }
                            p1--; p2++;
                        }
                    }
                }
            }

            // 验证是否是k进制的镜像数
            bool IsKMirror(long x)
            {
                List<long> digits = new();
                while (x > 0) { digits.Add(x % k); x /= k; }

                int pl = 0, pr = digits.Count - 1;
                while (pl < pr)
                {
                    if (digits[pl] != digits[pr]) return false;
                    pl++; pr--;
                }
                return true;
            }
        }
    }
}
