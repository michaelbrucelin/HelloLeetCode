using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1073
{
    public class Solution1073 : Interface1073
    {
        /// <summary>
        /// 数学
        /// 模拟加法，从低位到高位逐位相加，具体分析见Solution1073.md
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public int[] AddNegabinary(int[] arr1, int[] arr2)
        {
            int len = Math.Max(arr1.Length, arr2.Length);
            Array.Reverse(arr1); Array.Reverse(arr2);

            List<int> result = new List<int>(); int extra = 0;
            for (int i = 0; i < len; i++)
            {
                switch (IntIndex(arr1, i) + IntIndex(arr2, i) + extra)
                {
                    case 0: result.Add(0); extra = 0; break;
                    case 1: result.Add(1); extra = 0; break;
                    case 2:
                        result.Add(0);
                        Extra:;
                        if (IntIndex(arr1, i + 1) != 0 || IntIndex(arr2, i + 1) != 0)
                        {
                            extra = -1;
                        }
                        else
                        {
                            result.Add(1); extra = 1; i++;
                        }
                        break;
                    case 3:
                        result.Add(1); goto Extra;
                    default:
                        throw new Exception("logic error.");
                }
            }
            if (extra == 1) result.Add(1);
            for (int i = result.Count - 1; i > 0 && result[i] != 1; i--) result.RemoveAt(i);

            result.Reverse();
            return result.ToArray();
        }

        private int IntIndex(int[] arr, int index)
        {
            return index < arr.Length ? arr[index] : 0;
        }

        /// <summary>
        /// 与AddNegabinary()逻辑一样，只是不翻转原始数组
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public int[] AddNegabinary2(int[] arr1, int[] arr2)
        {
            int len = Math.Max(arr1.Length, arr2.Length);
            List<int> result = new List<int>(); int extra = 0;
            for (int i = 1; i <= len; i++)
            {
                switch (IntIndexTail(arr1, i) + IntIndexTail(arr2, i) + extra)
                {
                    case 0: result.Add(0); extra = 0; break;
                    case 1: result.Add(1); extra = 0; break;
                    case 2:
                        result.Add(0);
                        Extra:;
                        if (IntIndexTail(arr1, i + 1) != 0 || IntIndexTail(arr2, i + 1) != 0)
                        {
                            extra = -1;
                        }
                        else
                        {
                            result.Add(1); extra = 1; i++;
                        }
                        break;
                    case 3:
                        result.Add(1); goto Extra;
                    default:
                        throw new Exception("logic error.");
                }
            }
            if (extra == 1) result.Add(1);
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
