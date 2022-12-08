using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1812
{
    public class Solution1812 : Interface1812
    {
        public bool SquareIsWhite(string coordinates)
        {
            return (((coordinates[0] - 'a') + (coordinates[1] - '1')) & 1) == 1;
        }
    }
}
