using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2910
{
    public class Solution2910 : Interface2910
    {
        /// <summary>
        /// 暴力查找
        /// 有x个球，尝试每个盒子放k/k+1个是否可以，尝试 x%k < x/k 即可
        /// 例如有101个球，尝试 2与3， 101/2 = 50 余 1
        ///     那么余 1 与其中一个结果合并 1个，还有49个                                        1个
        ///     每将一组2个拆开，就需要另外2组两个与拆开的合并，即没3组可以变成2组，所以49/3*2  32个
        ///     上面49/3 余1个                                                                   1个
        /// 结果为34
        /// </summary>
        /// <param name="balls"></param>
        /// <returns></returns>
        public int MinGroupsForValidAssignment(int[] balls)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            for (int i = 0, ball, len = balls.Length; i < len; i++)
                if (freq.TryGetValue(ball = balls[i], out int cnt)) freq[ball] = ++cnt; else freq.Add(ball, 1);

            int result = 0, min = balls.Length;
            foreach (int cnt in freq.Values) { min = Math.Min(min, cnt); result += (cnt + 1) >> 1; }

            int _result; (int Quotient, int Remainder) dqr;
            for (int k = 2, x; k <= min; k++)                // 选择 k 与 k+1
            {
                _result = 0;
                foreach (int cnt in freq.Values)
                {
                    dqr = Math.DivRem(cnt, k);
                    if (dqr.Remainder > dqr.Quotient) goto CONTINUE;
                    _result += dqr.Remainder;
                    x = dqr.Quotient - dqr.Remainder;
                    dqr = Math.DivRem(x, k + 1);
                    _result += dqr.Quotient * k + dqr.Remainder;
                }
                result = Math.Min(result, _result);
            CONTINUE:;
            }

            return result;
        }
    }
}
