using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1146
{
    public class Solution1146
    {
    }

    /// <summary>
    /// 逻辑没问题，但是MLE
    /// </summary>
    public class SnapshotArray : Interface1146
    {
        public SnapshotArray(int length)
        {
            len = length;
            snapshot = new List<int[]> { new int[length] };
        }

        private int len;
        private List<int[]> snapshot;

        public int Get(int index, int snap_id)
        {
            return snapshot[snap_id][index];
        }

        public void Set(int index, int val)
        {
            snapshot[^1][index] = val;
        }

        public int Snap()
        {
            snapshot.Add(snapshot[^1].ToArray());
            return snapshot.Count - 2;
        }
    }
}
