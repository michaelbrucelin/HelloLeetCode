using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2336
{
    public class Solution2336
    {
    }

    /// <summary>
    /// 1. 使用一个有序数组，记录缺失的元素，初始时，数组为空
    /// 2. 弹出元素，就是去“缺失数组”中没有缺失的最小值
    ///     查找时，可以使用二分法
    /// </summary>
    public class SmallestInfiniteSet : Interface2336
    {
        public SmallestInfiniteSet()
        {
            lost = new List<int>() { 0 };    // 默认给一个0，这样缺失元素的正确索引就是其自身，二分时代码更简单
            set = new HashSet<int>() { 0 };
        }

        private List<int> lost;
        private HashSet<int> set;

        public void AddBack(int num)
        {
            if (set.Contains(num))
            {
                int left = 1, right = lost.Count - 1, mid = -1;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (lost[mid] == num) break;
                    if (lost[mid] < num) left = mid + 1; else right = mid - 1;
                }
                for (int i = mid; i < lost.Count - 1; i++) lost[i] = lost[i + 1];
                lost.RemoveAt(lost.Count - 1);
                set.Remove(num);
            }
        }

        public int PopSmallest()
        {
            int id = -1, left = 0, right = lost.Count - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (lost[mid] == mid)
                {
                    id = mid; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            lost.Add(-1);
            for (int i = lost.Count - 1; i > id + 1; i--) lost[i] = lost[i - 1];
            lost[id + 1] = id + 1;
            set.Add(id + 1);

            return id + 1;
        }
    }
}
