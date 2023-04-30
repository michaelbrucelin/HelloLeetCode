using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1337
{
    public class Solution1337 : Interface1337
    {
        /// <summary>
        /// 借助优先级队列整理topk
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] KWeakestRows(int[][] mat, int k)
        {
            Comparer<(int, int)> comparer = Comparer<(int, int)>.Create((t1, t2) => t1.Item1 != t2.Item1 ? t2.Item1 - t1.Item1 : t2.Item2 - t1.Item2);
            PriorityQueue<int, (int, int)> topk = new PriorityQueue<int, (int, int)>(comparer);

            for (int i = 0; i < mat.Length; i++)
            {
                int j = 0; for (; j < mat[i].Length && mat[i][j] != 0; j++) ;
                topk.Enqueue(i, (j, i));
                if (topk.Count > k) topk.Dequeue();
            }

            int[] result = new int[k];
            for (int i = k - 1; i >= 0; i--) result[i] = topk.Dequeue();

            return result;
        }

        /// <summary>
        /// 与KWeakestRows()一样，将查找每一行中有多少个1改为二分法查找
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] KWeakestRows2(int[][] mat, int k)
        {
            Comparer<(int, int)> comparer = Comparer<(int, int)>.Create((t1, t2) => t1.Item1 != t2.Item1 ? t2.Item1 - t1.Item1 : t2.Item2 - t1.Item2);
            PriorityQueue<int, (int, int)> topk = new PriorityQueue<int, (int, int)>(comparer);

            for (int i = 0; i < mat.Length; i++)
            {
                topk.Enqueue(i, (BinarySearch(mat[i]), i));
                if (topk.Count > k) topk.Dequeue();
            }

            int[] result = new int[k];
            for (int i = k - 1; i >= 0; i--) result[i] = topk.Dequeue();

            return result;
        }

        /// <summary>
        /// 与KWeakestRows2()一样，由于题目限制矩阵的行数与列数均<=100（7位二进制），所以可以优化优先级队列
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] KWeakestRows3(int[][] mat, int k)
        {
            PriorityQueue<int, int> topk = new PriorityQueue<int, int>();

            for (int i = 0; i < mat.Length; i++)
            {
                int cnt = BinarySearch(mat[i]);
                topk.Enqueue(i, -((cnt << 7) + i));
                if (topk.Count > k) topk.Dequeue();
            }

            int[] result = new int[k];
            for (int i = k - 1; i >= 0; i--) result[i] = topk.Dequeue();

            return result;
        }

        private int BinarySearch(int[] arr)
        {
            int result = -1, left = 0, right = arr.Length - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (arr[mid] == 1)
                {
                    result = mid; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result + 1;
        }
    }
}
