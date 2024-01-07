using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1603
{
    public class Solution1603
    {
    }

    public class ParkingSystem : Interface1603
    {
        public ParkingSystem(int big, int medium, int small)
        {
            empty = new int[] { big, medium, small };
        }

        int[] empty;

        public bool AddCar(int carType)
        {
            return --empty[carType - 1] >= 0;
        }
    }
}
