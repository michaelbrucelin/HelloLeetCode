using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1073
{
    public class Solution1073_2 : Interface1073
    {
        /// <summary>
        /// 数学
        /// 模拟加法，从低位到高位逐位相加，本质上与Solution1073是一样的
        /// 只不过写完Solution1073对加法多了一层理解，稍加优化，思路简单了，不一定更快
        /// 具体见Solution1073_2.md
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public int[] AddNegabinary(int[] arr1, int[] arr2)
        {
            int len = Math.Max(arr1.Length, arr2.Length);
            List<int> result = new List<int>(); int extra = 0;
            for (int i = 1; i <= len || extra != 0; i++)
            {
                switch (IntIndexTail(arr1, i) + IntIndexTail(arr2, i) + extra)
                {
                    case 0: result.Add(0); extra = 0; break;
                    case 1: result.Add(1); extra = 0; break;
                    case 2: result.Add(0); extra = -1; break;
                    case 3: result.Add(1); extra = -1; break;
                    case -1: result.Add(1); extra = 1; break;
                    default: throw new Exception("logic error.");
                }
            }
            for (int i = result.Count - 1; i > 0 && result[i] != 1; i--) result.RemoveAt(i);

            result.Reverse();
            return result.ToArray();
        }

        private int IntIndexTail(int[] arr, int index)
        {
            index = arr.Length - index;
            return index >= 0 ? arr[index] : 0;
        }
    }
}
