using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2037
{
    public class Solution2037 : Interface2037
    {
        public int MinMovesToSeat(int[] seats, int[] students)
        {
            int result = 0;

            Array.Sort(seats);
            Array.Sort(students);
            for (int i = 0; i < seats.Length; i++)
                result += Math.Abs(seats[i] - students[i]);

            return result;
        }
    }
}
