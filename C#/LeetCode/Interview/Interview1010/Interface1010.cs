using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1010
{
    /// <summary>
    /// Your StreamRank object will be instantiated and called as such:
    /// StreamRank obj = new StreamRank();
    /// obj.Track(x);
    /// int param_2 = obj.GetRankOfNumber(x);
    /// </summary>
    public interface Interface1010
    {
        // public StreamRank(){ }

        public void Track(int x);

        public int GetRankOfNumber(int x);
    }
}
