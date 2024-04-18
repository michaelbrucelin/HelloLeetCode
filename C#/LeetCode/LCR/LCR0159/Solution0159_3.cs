using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0159
{
    public class Solution0159_3 : Interface0159
    {
        private static Random random = new Random();

        /// <summary>
        /// TopK，基于快排
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="cnt"></param>
        /// <returns></returns>
        public int[] InventoryManagement(int[] stock, int cnt)
        {
            if (cnt == 0) return [];
            if (cnt == stock.Length) return stock;

            TopK(stock, cnt - 1);
            int[] result = new int[cnt];
            Array.Copy(stock, result, cnt);

            return result;
        }

        private void TopK(int[] nums, int k)
        {
            int lo = 0, hi = nums.Length - 1, _k = -1;
            while (_k != k)
            {
                if (_k < k)
                    _k = Partition(nums, random.Next(_k + 1, hi + 1), _k + 1, hi);
                else
                    _k = Partition(nums, random.Next(lo, _k), lo, _k - 1);
            }
        }

        private int Partition(int[] nums, int pivot_id, int lo, int hi)
        {
            Swap(nums, lo, pivot_id);
            int pl = lo, pr = hi + 1;
            int pivot = nums[lo];
            while (true)
            {
                while (nums[++pl] <= pivot) if (pl == hi) break;
                while (nums[--pr] >= pivot) if (pr == lo) break;
                if (pl >= pr) break;
                Swap(nums, pl, pr);
            }
            Swap(nums, lo, pr);

            return pr;
        }

        /*  这个不对
        private int Partition(int[] nums, int pivot_id, int left, int right)
        {
            Swap(nums, left, pivot_id);
            int pl = left, pr = right + 1, pivot = nums[left];
            while (++pl < --pr)
            {
                while (pl < pr && nums[pl] <= pivot) pl++;
                while (pr > pl && nums[pr] >= pivot) pr--;
                if (pl == pr) break;
                Swap(nums, pl, pr);
            }
            Swap(nums, left, pr);

            return pr;
        }
        */

        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i]; nums[i] = nums[j]; nums[j] = temp;
        }
    }
}
