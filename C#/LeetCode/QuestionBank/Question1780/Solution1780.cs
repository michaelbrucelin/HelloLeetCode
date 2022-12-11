using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1780
{
    public class Solution1780 : Interface1780
    {
        /// <summary>
        /// 二进制遍历 + 二分查找
        /// 1. 找出k，使得pow(3,k)<=n，pow(3,k+1)>n
        ///     这时，如果n可以被3的幂的和表示，一定在3^0, 3^1 ... 3^k之间选择，共2^(k+1)种可能，可以用0 - 2^(k+1)的二进制枚举
        /// 2. 如果x>=0且x<=2^(k+1)，数学上很容易证明x1>x2的话，x1二进制枚举表示的3的幂的和大于x2二进制枚举表示的3的幂的和（等比数列通项公式即可证明）
        /// 3. 用二分法即可找出结果
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool CheckPowersOfThree(int n)
        {
            int k = -1, m = 1;
            while (m < n) { m *= 3; k++; }
            if (m == n) return true;

            int left = 0, right = 1 << (k + 1);
            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);
                int sum = 0, base3 = 1, ptr = mid;
                while (ptr > 0)
                {
                    if ((ptr & 1) == 1) sum += base3;
                    ptr >>= 1;
                    base3 *= 3;
                }

                if (sum == n) return true;
                if (sum < n) left = mid + 1; else right = mid - 1;
            }

            return false;
        }
    }
}
