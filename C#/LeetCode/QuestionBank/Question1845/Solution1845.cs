using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1845
{
    //public class Solution1845:Interface1845
    //{
    //}

    public class SeatManager : Interface1845
    {
        public SeatManager(int n)
        {
            minpq = new PriorityQueue<int, int>();
            for (int i = 1; i <= n; i++) minpq.Enqueue(i, i);
        }

        PriorityQueue<int, int> minpq;

        public int Reserve()
        {
            return minpq.Dequeue();
        }

        public void Unreserve(int seatNumber)
        {
            minpq.Enqueue(seatNumber, seatNumber);
        }
    }
}
