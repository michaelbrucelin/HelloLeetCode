using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2578
{
    public class Solution2578 : Interface2578
    {
        /// <summary>
        /// 暴力 + 二进制枚举
        /// 1. 将num中每个位的数字拆分出来
        /// 2. 借助二进制枚举将这些数字分为两组
        /// 3. 每一组数字升序排列
        /// 4. 每一组数字生成整数求和
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int SplitNum(int num)
        {
            int result = num;
            List<int> digits = new List<int>();
            while (num > 0) { digits.Add(num % 10); num /= 10; }

            int cnt = digits.Count;
            List<int> digits1 = new List<int>(), digits2 = new List<int>();
            for (int dist = 1, _dist; dist < (1 << cnt); dist++)  // 二进制枚举
            {
                digits1.Clear(); digits2.Clear(); _dist = dist;
                for (int i = 0; i < cnt; i++)
                {
                    if ((_dist & 1) == 0) digits1.Add(digits[i]); else digits2.Add(digits[i]);
                    _dist >>= 1;
                }

                digits1.Sort(); digits2.Sort();
                int num1 = 0, num2 = 0;
                for (int i = 0; i < digits1.Count; i++) num1 = num1 * 10 + digits1[i];
                for (int i = 0; i < digits2.Count; i++) num2 = num2 * 10 + digits2[i];
                result = Math.Min(result, num1 + num2);
            }

            return result;
        }

        /// <summary>
        /// 略加优化，移除数字0
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int SplitNum2(int num)
        {
            int result = num;
            List<int> digits = new List<int>();
            while (num > 0) { if (num % 10 > 0) digits.Add(num % 10); num /= 10; }

            int cnt = digits.Count;
            List<int> digits1 = new List<int>(), digits2 = new List<int>();
            for (int dist = 1, _dist; dist < (1 << cnt); dist++)  // 二进制枚举
            {
                digits1.Clear(); digits2.Clear(); _dist = dist;
                for (int i = 0; i < cnt; i++)
                {
                    if ((_dist & 1) == 0) digits1.Add(digits[i]); else digits2.Add(digits[i]);
                    _dist >>= 1;
                }

                digits1.Sort(); digits2.Sort();
                int num1 = 0, num2 = 0;
                for (int i = 0; i < digits1.Count; i++) num1 = num1 * 10 + digits1[i];
                for (int i = 0; i < digits2.Count; i++) num2 = num2 * 10 + digits2[i];
                result = Math.Min(result, num1 + num2);
            }

            return result;
        }
    }
}
