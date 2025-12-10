using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1390
{
    public class Solution1390 : Interface1390
    {
        /// <summary>
        /// 暴力查找
        /// 1. 一个正整数只有4个因数，除却1与自身，那么其余两个一定是两个不等的质数（错的，27只有4个因数，但是不满足前面的结论）
        /// 2. 完全平方数一定不满足条件，因为一定会有奇数个因数
        /// 3. 使用Hash保存已经查询过的数字
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SumFourDivisors(int[] nums)
        {
            int result = 0, len = nums.Length;
            int[] cache = new int[100001];                       // 0:没查询, -1:不满足, >0:解，题目限定数组长度为10000，少了一个数量级，所以就不初始化cache为-1了
            for (int i = 1; i < 317; i++) cache[i * i] = -1;     // 317 = sqrt(100000) + 1
            for (int i = 0, j, num, sqrt; i < len; i++)
            {
                num = nums[i];
                if (cache[num] != 0)
                {
                    if (cache[num] != -1) result += cache[num];
                }
                else
                {
                    sqrt = (int)Math.Sqrt(num) + 1;
                    for (j = 2; j < sqrt; j++) if (num % j == 0) { cache[num] = 1 + num + j + (num / j); break; }
                    for (++j; j < sqrt; j++) if (num % j == 0) { cache[num] = -1; break; }
                    if (cache[num] != -1) result += cache[num];  // 这里可以加一个线性筛，即把num*2,num*3...加到cache中，值为-1
                }
            }

            return result;
        }
    }
}
