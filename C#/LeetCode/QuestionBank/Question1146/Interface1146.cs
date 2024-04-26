using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1146
{
    /// <summary>
    /// Your SnapshotArray object will be instantiated and called as such:
    /// SnapshotArray obj = new SnapshotArray(length);
    /// obj.Set(index,val);
    /// int param_2 = obj.Snap();
    /// int param_3 = obj.Get(index,snap_id);
    /// </summary>
    public interface Interface1146
    {
        // public SnapshotArray(int length) { }

        public void Set(int index, int val);

        public int Snap();

        public int Get(int index, int snap_id);
    }
}
