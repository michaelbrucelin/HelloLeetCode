using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0682
{
    public class Solution0682 : Interface0682
    {
        public int CalPoints(string[] operations)
        {
            int len = operations.Length, ptr = 0;
            int[] points = new int[len];
            for (int i = 0; i < len; i++)
            {
                switch (operations[i])
                {
                    case "+":
                        points[ptr] = points[ptr - 1] + points[ptr - 2];
                        ptr++;
                        break;
                    case "D":
                        points[ptr] = points[ptr - 1] << 1;
                        ptr++;
                        break;
                    case "C":
                        ptr--;
                        break;
                    default:
                        points[ptr++] = int.Parse(operations[i]);
                        break;
                }
            }

            int result = 0;
            for (int i = 0; i < ptr; i++) result += points[i];
            return result;
        }
    }
}
