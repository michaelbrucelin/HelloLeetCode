using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1089
{
    public class Solution1089 : Interface1089
    {
        /// <summary>
        /// 借助额外的空间
        /// </summary>
        /// <param name="arr"></param>
        public void DuplicateZeros3(int[] arr)
        {
            int ptr = 0, len = arr.Length;
            int[] buffer = new int[len];
            for (int i = 0; ptr < len && i < len; i++)
            {
                buffer[ptr++] = arr[i];
                if (arr[i] == 0)
                {
                    if (ptr < len) buffer[ptr++] = 0; else break;
                }
            }

            Array.Copy(buffer, arr, len);
        }

        /// <summary>
        /// 双指针
        /// 同DuplicateZeros()，由于题目限定数组的每一项都小于10，所以可以原地“借助额外的空间”
        /// </summary>
        /// <param name="arr"></param>
        public void DuplicateZeros2(int[] arr)
        {
            int ptr = 0, len = arr.Length;
            for (int i = 0, num; i < len; i++)
            {
                num = arr[i] % 10;
                if (ptr < len) arr[ptr++] += num * 10;
                if (num == 0 && ptr < len) ptr++;       // arr[ptr++] += 0 * 10;
                arr[i] /= 10;
            }
        }

        /// <summary>
        /// 双指针
        /// 同DuplicateZeros2()，改为位运算
        /// </summary>
        /// <param name="arr"></param>
        public void DuplicateZeros(int[] arr)
        {
            int ptr = 0, len = arr.Length;
            for (int i = 0, num; i < len; i++)
            {
                num = arr[i] & 15;
                if (ptr < len) arr[ptr++] |= num << 4;
                if (num == 0 && ptr < len) ptr++;       // arr[ptr++] |= 0 << 4;
                arr[i] >>= 4;
            }
        }
    }
}
