using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1146
{
    public class Solution1146_2
    {
    }

    /// <summary>
    /// 逻辑同Solution1146，但是将快照由数组改为Hash，只记录变更部分，来优化空间复杂度
    /// </summary>
    public class SnapshotArray_2 : Interface1146
    {
        public SnapshotArray_2(int length)
        {
            snapshot = new List<Dictionary<int, int>> { new Dictionary<int, int>() };
        }

        private List<Dictionary<int, int>> snapshot;

        public int Get(int index, int snap_id)
        {
            if (snap_id == -1) return 0;
            if (snapshot[snap_id].ContainsKey(index)) return snapshot[snap_id][index];
            return Get(index, snap_id - 1);
        }

        public void Set(int index, int val)
        {
            if (snapshot[^1].ContainsKey(index)) snapshot[^1][index] = val; else snapshot[^1].Add(index, val);
        }

        public int Snap()
        {
            snapshot.Add(new Dictionary<int, int>());
            return snapshot.Count - 2;
        }
    }
}
