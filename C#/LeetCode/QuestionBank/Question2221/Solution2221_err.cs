using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2221
{
    public class Solution2221_err : Interface2221
    {
        /// <summary>
        /// 数学
        /// 假定数组长度为n，则最终结果为nums[0]*a0 + nums[1]*a1 + ... + nums[n-1]*a(n-1)
        /// 其中a0, a1, ... 是杨辉三角的值
        /// 
        /// 下面这种计算组合数的方法果然不靠谱，参考下面数组
        /// [2,6,6,5,5,3,3,8,6,4,3,3,5,1,0,1,3,6,9]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int TriangularSum(int[] nums)
        {
            int result = 0, n = nums.Length - 1, m = (nums.Length - 2) >> 1;
            for (int i = 0; i <= m; i++) result = (result + (nums[i] + nums[n - i]) * Combination(n, i)) % 10;
            if ((n & 1) == 0) result = (result + nums[n >> 1] * Combination(n, (n >> 1))) % 10;

            return result;

            int Combination(int n, int k)
            {
                if (k == 0) return 1;
                if (k == 1) return n % 10;

                Queue<int> queue1 = new Queue<int>(), queue2 = new Queue<int>();
                for (int i = n - k + 1; i <= n; i++) queue1.Enqueue(i);
                for (int i = k; i > 1; i--) queue2.Enqueue(i);
                for (int i = 1, x, y; i < k; i++)                               // 做个尝试，没有严谨证明这样一定可完全约分分母
                {                                                               // 复杂的策略可以达到效果，例如按照质因数约分
                    y = queue2.Dequeue();                                       // 如果那样复杂，不如直接使用BigInteger来实现了
                    while ((x = queue1.Dequeue()) % y != 0) queue1.Enqueue(x);  // 所以这样来试试
                    queue1.Enqueue(x / y);
                }

                int result = 1;
                while (queue1.Count > 0) result = result * (queue1.Dequeue() % 10) % 10;
                return result;
            }
        }
    }
}
