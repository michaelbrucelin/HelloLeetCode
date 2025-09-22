using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3508
{
    /// <summary>
    /// Your Router object will be instantiated and called as such:
    /// Router obj = new Router(memoryLimit);
    /// bool param_1 = obj.AddPacket(source,destination,timestamp);
    /// int[] param_2 = obj.ForwardPacket();
    /// int param_3 = obj.GetCount(destination,startTime,endTime);
    /// </summary>
    public interface Interface3508
    {
        // public Router(int memoryLimit){}

        public bool AddPacket(int source, int destination, int timestamp);

        public int[] ForwardPacket();

        public int GetCount(int destination, int startTime, int endTime);
    }
}
