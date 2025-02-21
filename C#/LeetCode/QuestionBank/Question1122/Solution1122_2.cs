using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1122
{
    public class Solution1122_2 : Interface1122
    {
        /// <summary>
        /// 计数排序
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            int min = arr1[0], max = arr1[0];
            for (int i = 0; i < arr1.Length; i++)
            {
                min = Math.Min(min, arr1[i]); max = Math.Max(max, arr1[i]);
            }

            int[] freq = new int[max - min + 1];
            for (int i = 0; i < arr1.Length; i++) freq[arr1[i] - min]++;

            int ptr = 0;
            for (int i = 0, num = 0, id = 0; i < arr2.Length; i++)
            {
                num = arr2[i]; id = num - min;
                for (int j = 0; j < freq[id]; j++) arr1[ptr++] = num;
                freq[id] = 0;
            }
            for (int i = 0; i < freq.Length; i++) for (int j = 0, num = i + min; j < freq[i]; j++)
                {
                    arr1[ptr++] = num;
                }

            return arr1;
        }
    }
}
