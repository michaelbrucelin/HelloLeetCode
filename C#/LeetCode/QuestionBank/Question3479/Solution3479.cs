using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3479
{
    public class Solution3479 : Interface3479
    {
        /// <summary>
        /// 线段树 + 二分
        /// 使用线段树表示 baskets，二分查找出第一个大于等于 target 的位置，并将其更新为 -1
        /// </summary>
        /// <param name="fruits"></param>
        /// <param name="baskets"></param>
        /// <returns></returns>
        public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
        {
            int result = fruits.Length, len = fruits.Length;
            SegmentTree segment = new SegmentTree(baskets, 0, len - 1);
            for (int i = 0, idx; i < len; i++) if ((idx = binarySearch(fruits[i])) != -1)
                {
                    result--;
                    segment.Update(idx, -1);
                }

            return result;

            int binarySearch(int target)
            {
                int result = -1, left = 0, right = len - 1, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (segment.Getmax(0, mid) >= target)
                    {
                        result = mid; right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }

                return result;
            }
        }

        public class SegmentTree
        {
            public SegmentTree(int[] nums, int left, int right)
            {
                this.nums = nums; this.left = left; this.right = right;
                Build();
            }

            private int[] nums;
            private int left, right, maxval = -1;
            private SegmentTree lchild, rchild;

            private void Build()
            {
                if (left == right) { maxval = nums[left]; return; }
                int mid = left + ((right - left) >> 1);
                lchild = new SegmentTree(nums, left, mid);
                rchild = new SegmentTree(nums, mid + 1, right);
                maxval = Math.Max(lchild.maxval, rchild.maxval);
            }

            public void Update(int idx, int val)
            {
                if (left == right) { maxval = val; return; }
                int mid = left + ((right - left) >> 1);
                if (idx <= mid) lchild.Update(idx, val); else rchild.Update(idx, val);
                maxval = Math.Max(lchild.maxval, rchild.maxval);
            }

            public int Getmax(int start, int end)
            {
                if (start == left && end == right) return maxval;
                int mid = left + ((right - left) >> 1);
                if (end <= mid) return lchild.Getmax(start, end);
                if (start > mid) return rchild.Getmax(start, end);
                return Math.Max(lchild.Getmax(start, mid), rchild.Getmax(mid + 1, end));
            }
        }
    }
}
