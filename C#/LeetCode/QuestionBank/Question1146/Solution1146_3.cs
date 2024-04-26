using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1146
{
    public class Solution1146_3
    {
    }

    /// <summary>
    /// 换一个思路
    /// Solution1146_2中，相当于每次快照记录这一次的全部变化
    ///     这样做有一个缺点就是，如果指定快照出没有值，只能递归逐一向前找，很慢
    /// 这里换一个思路，数组的每一这位置单独记录快照
    ///     这样的话，如果指定位置没有快照，可以二分向前查找
    /// </summary>
    public class SnapshotArray_3 : Interface1146
    {
        public SnapshotArray_3(int length)
        {
            snapid = 0;
            snapshot = new List<(int snapid, int val)>[length];
            for (int i = 0; i < length; i++)
                snapshot[i] = new List<(int snapid, int val)>() { (0, 0) };
        }

        private int snapid;
        private List<(int snapid, int val)>[] snapshot;

        public int Get(int index, int snap_id)
        {
            int result = 0, left = 0, right = snapshot[index].Count - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (snapshot[index][mid].snapid <= snap_id)
                {
                    result = snapshot[index][mid].val; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }

        public void Set(int index, int val)
        {
            if (snapshot[index][^1].snapid != snapid)
                snapshot[index].Add((snapid, val));
            else
                snapshot[index][^1] = (snapid, val);
        }

        public int Snap()
        {
            return snapid++;
        }
    }
}
