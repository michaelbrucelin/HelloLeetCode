using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1845
{
    /// <summary>
    /// Your SeatManager object will be instantiated and called as such:
    /// SeatManager obj = new SeatManager(n);
    /// int param_1 = obj.Reserve();
    /// obj.Unreserve(seatNumber);
    /// </summary>
    public interface Interface1845
    {
        // public SeatManager(int n){}

        public int Reserve();

        public void Unreserve(int seatNumber);
    }
}
