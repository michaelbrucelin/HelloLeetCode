using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1643
{
    public class Solution1643 : Interface1643
    {
        /// <summary>
        /// 逐位判断
        /// 只有两个元素，假定m个H，n个V，那么
        ///     第一个元素是H，有 m-1 个H，n 个V 的组合数个字符串
        ///     第一个元素是V，有 m 个H，n-1 个V 的组合数个字符串
        /// 根据k就知道第1个字符是H还是V，同理可以后面每一个字符
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string KthSmallestPath(int[] destination, int k)
        {
            int idx = 0, cnth = destination[1], cntv = destination[0];
            int len = cnth + cntv; long cnt;
            char[] result = new char[len];
            while (cnth > 0 && cntv > 0)
            {
                cnt = count(cnth - 1, cntv);
                if (k <= cnt) { result[idx] = 'H'; cnth--; } else { result[idx] = 'V'; cntv--; k -= (int)cnt; }
                idx++;
            }
            switch ((cnth, cntv))
            {
                case ( > 0, 0): Array.Fill(result, 'H', idx, len - idx); break;
                case (0, > 0): Array.Fill(result, 'V', idx, len - idx); break;
                default: break;
            }

            return new string(result);

            static long count(int x, int y)
            {
                if (x > y) (x, y) = (y, x);

                long result = 1;
                for (int i = 0; i < x; i++) result *= x + y - i;
                for (int i = x; i > 1; i--) result /= i;

                return result;
            }
        }
    }
}
