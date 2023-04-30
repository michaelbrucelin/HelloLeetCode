using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1053
{
    public class Solution1053_2 : Interface1053
    {
        public int[] PrevPermOpt1(int[] arr)
        {
            int len = arr.Length;
            for (int i = len - 2; i >= 0; i--)
            {
                if (arr[i] > arr[i + 1])
                {
                    int id = len - 1;
                    while (arr[id] >= arr[i] || arr[id - 1] == arr[id]) id--;
                    int t = arr[i]; arr[i] = arr[id]; arr[id] = t;
                    break;
                }
            }

            return arr;
        }

        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] PrevPermOpt12(int[] arr)
        {
            int len = arr.Length;
            for (int i = len - 2; i >= 0; i--)
            {
                if (arr[i] > arr[i + 1])
                {
                    int id = i, left = i + 1, right = len - 1, mid;
                    while (left <= right)
                    {
                        mid = left + ((right - left) >> 1);
                        if (arr[mid] < arr[i])
                        {
                            id = mid; left = mid + 1;
                        }
                        else
                        {
                            right = mid - 1;
                        }
                    }
                    while (arr[id - 1] == arr[id]) id--;

                    if (id != i)
                    {
                        int t = arr[i]; arr[i] = arr[id]; arr[id] = t;
                    }

                    break;
                }
            }

            return arr;
        }
    }
}
