using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1223
{
    public class Solution1223_2 : Interface1223
    {
        private const int MOD = 1000000007;

        /// <summary>
        /// BFS
        /// 前4个测试用例可以通过，逻辑应该没有问题，但是测试数据大就跑不出来了，参考测试用例4-7
        /// 
        /// 没想明白能不能用类似于容斥原理等方式，直接数学推导出来，先BFS解一下
        /// </summary>
        /// <param name="n"></param>
        /// <param name="rollMax"></param>
        /// <returns></returns>
        public int DieSimulator(int n, int[] rollMax)
        {
            if (n == 1) return 6;

            Queue<(int point, int freq, int count)> queue = new Queue<(int point, int freq, int count)>();
            for (int i = 1; i <= 6; i++) queue.Enqueue((i, 1, 1));
            for (int i = 1, cnt = 6; i < n; i++, cnt = queue.Count())
            {
                for (int j = 0; j < cnt; j++)
                {
                    var info = queue.Dequeue();
                    for (int k = 1; k <= 6; k++)
                    {
                        if (k != info.point)
                        {
                            queue.Enqueue((k, 1, info.count));
                        }
                        else
                        {
                            if (info.freq < rollMax[k - 1]) queue.Enqueue((k, info.freq + 1, info.count));
                        }
                    }
                }
            }

            int result = 0;
            while (queue.Count > 0)
            {
                result += queue.Dequeue().count % MOD; result %= MOD;
            }
            return result;
        }
    }
}
